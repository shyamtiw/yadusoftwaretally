using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business
{
    public partial class StateLevel

    {
        public static List<States> GetList()
        {
            List<States> StateLIst = new List<States>();



            StateLIst.Add(new States() { SateCode = "01", StateName = "JAMMU AND KASHMIR"});
            StateLIst.Add(new States() { SateCode = "02", StateName = "HIMACHAL PRADESH"});
            StateLIst.Add(new States() { SateCode = "03", StateName = "PUNJAB"});
            StateLIst.Add(new States() { SateCode = "04", StateName = "CHANDIGARH"});
            StateLIst.Add(new States() { SateCode = "05", StateName = "UTTARAKHAND"});
            StateLIst.Add(new States() { SateCode = "06", StateName = "HARYANA"});
            StateLIst.Add(new States() { SateCode = "07", StateName = "DELHI"});
            StateLIst.Add(new States() { SateCode = "08", StateName = "RAJASTHAN"});
            StateLIst.Add(new States() { SateCode = "09", StateName = "UTTAR PRADESH"});
            StateLIst.Add(new States() { SateCode = "10", StateName = "BIHAR"});
            StateLIst.Add(new States() { SateCode = "11", StateName = "SIKKIM"});
            StateLIst.Add(new States() { SateCode = "12", StateName = "ARUNACHAL PRADESH"});
            StateLIst.Add(new States() { SateCode = "13", StateName = "NAGALAND"});
            StateLIst.Add(new States() { SateCode = "14", StateName = "MANIPUR"});
            StateLIst.Add(new States() { SateCode = "15", StateName = "MIZORAM"});
            StateLIst.Add(new States() { SateCode = "16", StateName = "TRIPURA"});
            StateLIst.Add(new States() { SateCode = "17", StateName = "MEGHLAYA"});
            StateLIst.Add(new States() { SateCode = "18", StateName = "ASSAM"});
            StateLIst.Add(new States() { SateCode = "19", StateName = "WEST BENGAL"});
            StateLIst.Add(new States() { SateCode = "20", StateName = "JHARKHAND"});
            StateLIst.Add(new States() { SateCode = "21", StateName = "ODISHA"});
            StateLIst.Add(new States() { SateCode = "22", StateName = "CHATTISGARH"});
            StateLIst.Add(new States() { SateCode = "23", StateName = "MADHYA PRADESH"});
            StateLIst.Add(new States() { SateCode = "24", StateName = "GUJARAT"});
            StateLIst.Add(new States() { SateCode = "26", StateName = "DADRA AND NAGAR HAVELI AND DAMAN AND DIU (NEWLY MERGED UT)"});
            StateLIst.Add(new States() { SateCode = "27", StateName = "MAHARASHTRA"});
            StateLIst.Add(new States() { SateCode = "28", StateName = "ANDHRA PRADESH(BEFORE DIVISION)"});
            StateLIst.Add(new States() { SateCode = "29", StateName = "KARNATAKA"});
            StateLIst.Add(new States() { SateCode = "30", StateName = "GOA"});
            StateLIst.Add(new States() { SateCode = "31", StateName = "LAKSHWADEEP"});
            StateLIst.Add(new States() { SateCode = "32", StateName = "KERALA"});
            StateLIst.Add(new States() { SateCode = "33", StateName = "TAMIL NADU"});
            StateLIst.Add(new States() { SateCode = "34", StateName = "PUDUCHERRY"});
            StateLIst.Add(new States() { SateCode = "35", StateName = "ANDAMAN AND NICOBAR ISLANDS"});
            StateLIst.Add(new States() { SateCode = "36", StateName = "TELANGANA"});
            StateLIst.Add(new States() { SateCode = "37", StateName = "ANDHRA PRADESH (NEWLY ADDED)"});
            StateLIst.Add(new States() { SateCode = "38", StateName = "LADAKH (NEWLY ADDED)"});



            return StateLIst.ToList();
        }
    }



    public partial class States
    {
        public string StateName { get; set; }
        public string SateCode { get; set; }

    }
}