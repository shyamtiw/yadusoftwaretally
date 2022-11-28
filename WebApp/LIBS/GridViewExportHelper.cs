using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.LIBS
{
    public class GridViewExportHelper
    {
        private HtmlTextWriter writer;
        public HtmlTextWriter Writer
        {
            get { return writer = writer ?? new HtmlTextWriter(new StringWriter()); }
            set { writer = value; }
        }

        public string GetExportGridContent(GridView gridView, bool preserveStyles, bool preserveLinks)
        {
            RenderGrid(gridView, preserveStyles, preserveLinks);
            return Writer.InnerWriter.ToString();
        }

        private void RenderGrid(GridView gridView, bool preserveStyles, bool preserveLinks)
        {
            Table table = (Table)gridView.Controls[0];
            bool hasHeader = gridView.HeaderRow != null;
            bool hasFooter = gridView.FooterRow != null;

            table.GridLines = gridView.GridLines;

            for (int i = 0; i < table.Rows.Count; i++)
            {
                for (int j = gridView.Columns.Count - 1; j >= 0; j--)
                {
                    if (!gridView.Columns[j].Visible && table.Rows[i].Cells.Count > j)
                    {
                        table.Rows[i].Cells.RemoveAt(j);
                    }
                }

                TableItemStyle style = null;
                if (preserveStyles)
                {
                    if (i == 0 && hasHeader)
                    {
                        style = gridView.HeaderStyle;
                    }
                    else if (i == table.Rows.Count - 1 && hasFooter)
                    {
                        style = gridView.FooterStyle;
                    }
                    else
                    {
                        style = gridView.RowStyle;
                    }
                }
                TransformRow(table.Rows[i], style, preserveLinks);
            }

            table.RenderControl(Writer);
        }

        private static void TransformRow(Control control, Style style, bool preserveLinks)
        {
            if (control is WebControl && style != null)
            {
                ((WebControl)control).ApplyStyle(style);
            }

            for (int i = control.Controls.Count - 1; i >= 0; i--)
            {
                Control child = control.Controls[i];

                if (!preserveLinks && typeof(LinkButton).IsAssignableFrom(child.GetType()))
                {
                    control.Controls.Remove(child);
                    control.Controls.AddAt(i, new LiteralControl(((LinkButton)child).Text));
                }
                else if (typeof(ImageButton).IsAssignableFrom(child.GetType()))
                {
                    control.Controls.Remove(child);
                    control.Controls.AddAt(i, new LiteralControl(((ImageButton)child).AlternateText));
                }
                else if (!preserveLinks && typeof(HyperLink).IsAssignableFrom(child.GetType()))
                {
                    control.Controls.Remove(child);
                    control.Controls.AddAt(i, new LiteralControl(((HyperLink)child).Text));
                }
                else if (typeof(ListControl).IsAssignableFrom(child.GetType()))
                {
                    control.Controls.Remove(child);
                    control.Controls.AddAt(i, new LiteralControl(((ListControl)child).SelectedItem.Text));
                }
                else if (typeof(ICheckBoxControl).IsAssignableFrom(child.GetType()))
                {
                    control.Controls.Remove(child);
                    control.Controls.AddAt(i, new LiteralControl(((ICheckBoxControl)child).Checked ? "True" : "False"));
                }

                if (child.HasControls())
                {
                    TransformRow(child, null, preserveLinks);
                }
            }
        }
    }
}