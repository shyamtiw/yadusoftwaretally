using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;
using WebApp.LIBS;
using System.Transactions;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;
using System.IO;

namespace WebApp
{
    public partial class insertdata : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void InsertData_Click(object sender, EventArgs e)
        {
            HSSFWorkbook hssfwb;
            var GetData = new List<GetTata>();


            string filename = Path.GetFileName(Server.MapPath(file.FileName));
            var fileExt = Path.GetExtension(filename); 

            hssfwb = new HSSFWorkbook(file.PostedFile.InputStream);
            var objClass = Global.Context.ClassMasters.AsEnumerable().ToList();
            var objSection = Global.Context.Sections.AsEnumerable().ToList();
            ISheet sheet = hssfwb.GetSheetAt(0);

            try
            {
                for (int row = 0; row <= sheet.LastRowNum; row++)
                {
                    if (sheet.GetRow(row) != null)
                    {

                        var insertobj = new GetTata();
                        try
                        {
                            insertobj.SR = sheet.GetRow(row).GetCell(0).NumericCellValue.ToString();
                        }
                        catch
                        {
                            insertobj.SR = sheet.GetRow(row).GetCell(0).StringCellValue;
                        }

                        insertobj.name = sheet.GetRow(row).GetCell(1).StringCellValue;
                        insertobj.Gender = sheet.GetRow(row).GetCell(2).StringCellValue;
                        try
                        {
                            insertobj.DOB = sheet.GetRow(row).GetCell(3).DateCellValue;
                        }
                        catch { }
                        try {

                            insertobj.Class = GetCLass(objClass, sheet.GetRow(row).GetCell(4).StringCellValue.Trim());
                        } catch { insertobj.Class = GetCLass(objClass, sheet.GetRow(row).GetCell(4).NumericCellValue.ToString().Trim()); }
                        
                        insertobj.Section = GetSection(objSection, sheet.GetRow(row).GetCell(5).StringCellValue.Trim());
                        insertobj.Address = sheet.GetRow(row).GetCell(6).StringCellValue.Trim();
                        try
                        {
                            insertobj.FatherContact = sheet.GetRow(row).GetCell(7).StringCellValue;
                        }
                        catch { insertobj.FatherContact = sheet.GetRow(row).GetCell(7).NumericCellValue.ToString(); }
                        insertobj.Community = sheet.GetRow(row).GetCell(8).StringCellValue;
                        insertobj.MotherName = sheet.GetRow(row).GetCell(9).StringCellValue;
                        try
                        {
                            insertobj.DateOfAmisston = sheet.GetRow(row).GetCell(10).DateCellValue;
                        }
                        catch { }
                        insertobj.Caste = sheet.GetRow(row).GetCell(11).StringCellValue;
                 
              
                                insertobj.AadharNo = "";
                    


                        try
                        {
                            insertobj.FatherName = sheet.GetRow(row).GetCell(13).StringCellValue;
                        }
                        catch { }

                        try
                        {
                            insertobj.Religen = sheet.GetRow(row).GetCell(14).StringCellValue;
                        }
                        catch { insertobj.Religen = ""; }
                        try
                        {
                            insertobj.IsRTE = sheet.GetRow(row).GetCell(15).StringCellValue=="Yes"?true:false;
                        }
                        catch { insertobj.Religen = ""; }



                        GetData.Add(insertobj);
                    }
                }
            }
            catch(Exception ex) {

              
            }

          

                GetData.ForEach(p =>
                        {
                      
                            var obj = new Business.StudentMaster();
                            obj.StudentName = p.name;

                       
                            obj.Caste = "";
                            obj.Nationality = "Indian";
                            obj.AadharNo = "";
                            obj.Community = p.Community;
                            obj.RESIDENTIALADDRESS = "";
                            obj.MotherContact = "";

                            
                            obj.FatherEducational = "";
                            obj.FatherOccupation = "";
                            obj.Mother = "";
                            obj.MotherEducational = "";

                            obj.MotherOccupation = "";
                            obj.PreviousSchool = "";
                            obj.PreviousYear = "";
                            obj.obtainedGradeMaks = "";
                            obj.PreviousSchoolAffiliated = "";
                            obj.FatherContact = "";

                            obj.SchoolId = 1;



                            obj.Gender = p.Gender;
                            if (p.DOB != null)
                            {
                                obj.DOB = p.DOB;
                            }
                           

                            obj.RESIDENTIALADDRESS = p.Address;
                            obj.FatherContact = p.FatherContact;
                            obj.Community = p.Community;
                            obj.Mother = p.MotherName;
                            if (p.DateOfAmisston != null)
                            {
                                obj.AdmitionDate = p.DateOfAmisston;
                            }
                            obj.Caste = p.Caste;
                            obj.AadharNo = p.AadharNo;

                            obj.RTE = p.IsRTE;
                            obj.Religion = p.Religen;

                            obj.Father = p.FatherName;
                            obj.Save();
                            Business.StuCl objcls = new StuCl();
                            objcls.ClassId = p.Class;
                            objcls.SRNo = p.SR;
                            objcls.SectionId = p.Section;
                            objcls.SchoolId = 1;
                            objcls.StudentId = obj.StudentId;
                            objcls.SessionId = 28;
                            objcls.Status = "Passed";
                            objcls.IsNew = false;



                            objcls.Save();


                            Business.UserLogin UserLoginUser = new UserLogin();

                            UserLoginUser.UserName = "mps" + obj.StudentId.ToString();

                            UserLoginUser.Password = obj.FatherContact;
                            UserLoginUser.IsActive = true;


                            UserLoginUser.RoleId = 4;

                            UserLoginUser.Save();
                            var objstu = Global.Context.StudentMasters.SingleOrDefault(px => px.StudentId == obj.StudentId);
                            objstu.UserId = UserLoginUser.UserLoginId;
                            objstu.Save();


                        });
            
            Response.Redirect("studentlist.aspx?save=save");
        }

        private int GetCLass(List<Business.ClassMaster> obj, string name)
        {
            try
            {
                return obj.Where(p => p.ClassName.Trim().ToUpper() == (name.Trim().ToUpper())).FirstOrDefault().ClassMasterId;
            }
            catch
            {

                return 0;
            }
        }

        private int GetSection(List<Business.Section> obj, string name)
        {
            try
            {
                return obj.Where(p => p.SectionName == (name.Trim().ToUpper())).FirstOrDefault().Sectionid;
            }
            catch
            {

                return 0;
            }
        }

        protected void insertdaa_Click(object sender, EventArgs e)
        {
            HSSFWorkbook hssfwb;
            var GetData = new List<GetTata>();


            string filename = Path.GetFileName(Server.MapPath(file.FileName)); //get the uploaded file name  
            var fileExt = Path.GetExtension(filename); //get the extension of uploaded excel file  

            hssfwb = new HSSFWorkbook(file.PostedFile.InputStream); //HSSWorkBook object will read the Excel 97-2000 formats  




        }
    }
}

public class GetTata
{
    public string SR { get; set; }
    public string name { get; set; }
    public string Gender { get; set; }
    public DateTime DOB { get; set; }
    public int Class { get; set; }
    public int Section { get; set; }
    public string Address { get; set; }
    public string FatherContact { get; set; }
    public string Community { get; set; }
    public string MotherName { get; set; }
    public DateTime DateOfAmisston { get; set; }
    public string Caste { get; set; }
    public string AadharNo { get; set; }
    public string FatherName { get; set; }
    public bool IsRTE { get; set; }
    public string Religen { get; set; }


}