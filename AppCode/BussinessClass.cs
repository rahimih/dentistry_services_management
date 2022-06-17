using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAcessClass;

namespace BussinessClass
{
    public class BussinessClass
    {

        public class userchecking
        {

            public string conectionstring;
            public System.Data.SqlClient.SqlDataReader datasource;
            public System.Data.SqlClient.SqlCommand usercheckingclientdataset;
            protected DataAcessClass.DataAcessClass.dataworker dataworkerObj;

            public int GroupIdentityNumber;
            public int FileIdentityNumber;

            public userchecking()
            {
                dataworkerObj = new DataAcessClass.DataAcessClass.dataworker();
                usercheckingclientdataset = dataworkerObj.clientdataset;
                conectionstring = dataworkerObj.conectionstring;
            }


            public bool Dbconnset(bool connected)
            {
                if (connected)
                    dataworkerObj.openconn();
                else
                    dataworkerObj.closeconn();
                return connected;
            }

            public bool Userlogin_checking(

                                    string username,
                                    string password
                                  )
            {
                return dataworkerObj.generalselect
                (
                  " TblUsers left join AcessLevel on TblUsers.usercode=AcessLevel.usercode ",
                  " * ",
                  " active = 1 and username=  ''" + username.ToString() + " ''" +
                  " and password=  ''" + password.ToString() + " ''"

                );
            }

            public bool viewusers()
            {
                return dataworkerObj.generalselect
               (
                 " TblUsers left join userkind on TblUsers.groupcode=userkind.groupcode ",
                 " TblUsers.UserCode, TblUsers.personalNO, TblUsers.Fname, TblUsers.Lname, TblUsers.SN, TblUsers.EnglishName, userKind.GroupName,tblusers.phone,TblUsers.mobile  ",
                 " 1=1 "
                 );
            }

            public int Changepassword(int usercode, string password)
            {
                return dataworkerObj.generalupdate("AcessLevel", "password = " + "''" + password + "''", "usercode = " + usercode.ToString());
            }

            public bool viewacesslevel(int usercode)
            {
                return dataworkerObj.generalselect
               (
                 " AcessLevel ",
                 " * ",
                 " UserCode =  " + usercode
                 );
            }

            public bool viewdoctorslist()
            {
                return dataworkerObj.generalselect("tblusers", "PersianTitle+'' ''+fname+'' ''+lname as drname, usercode", " TblUsers.GroupCode=2 and UserCode not in (select Dentist_code from family_dentist )");
            }

            public bool  viewdentistfamily()
            {
                return dataworkerObj.generalselect("TblUsers INNER JOIN Family_Dentist ON TblUsers.UserCode = Family_Dentist.Dentist_code", "TblUsers.PersianTitle + '' '' + TblUsers.Fname + '' '' + TblUsers.Lname AS drname, Family_Dentist.Dentist_code, status", "1=1");
            }


            public bool search_persontbl(string persno)
            {
                return dataworkerObj.search_persontbl(persno);
            }

            public string search_screen_count(int doctorscode,int shiftcode)
            {
                return dataworkerObj.generalselect_count("Screen_count", "Screen_count as F1", "doctorscode=" + doctorscode + " and shiftcode="+ shiftcode);
            }

            public string getnames()
            {
                return dataworkerObj.generalselect_count("names" , "name as F1", "1=1");
            }

        }
        public class EventsLog
        {
            public System.Data.SqlClient.SqlDataReader datasource;
            public System.Data.SqlClient.SqlCommand EventsLogclientdataset;
            protected DataAcessClass.DataAcessClass.dataworker dataworkerObj;

            public EventsLog()
            {
                dataworkerObj = new DataAcessClass.DataAcessClass.dataworker();
                EventsLogclientdataset = dataworkerObj.clientdataset;
            }


            public bool Dbconnset(bool connected)
            {
                if (connected)
                    dataworkerObj.openconn();
                else
                    dataworkerObj.closeconn();
                return connected;
            }

            public Int64 insertEventsLog(

                                                  string usercode,
                                                  string logdate,
                                                  string logtime,
                                                  int Logcode,
                                                  string IPAdress,
                                                  int changecode
                                                 )
            {
                return dataworkerObj.generalinsert
                (
                " EventsLog ",
                " usercode,logdate,logtime,Logcode,IPAdress,changecode",
                "''" + usercode + "''" + " , " +
                "''" + logdate + "''" + " , " +
                "''" + logtime + "''" + " , " +
                Logcode + " , " +
                "''" + IPAdress + "''" + " , " +
                changecode
                );
            }


            public bool findEventsLog(int EventsLogCode)
            {
                return dataworkerObj.generalselect
                (
                " EventsLog ",
                " * ",
                " EventsLogCode= " + EventsLogCode.ToString()
                );
            }

            public string selectEventsLog(string fields, string conditon)
            {
                return dataworkerObj.generalselect_count
                 (
                 " EventsLog ",
                 fields
                 ,
                 conditon
                 );

            }


            public bool log_view(string fromdate, string todate, string kind) 
            {
                return dataworkerObj.log_view(fromdate, todate, kind);
            }


        }
        public class Clinics
        {
            public System.Data.SqlClient.SqlDataReader datasource;
            public System.Data.SqlClient.SqlCommand Clinicsclientdataset;
            protected DataAcessClass.DataAcessClass.dataworker dataworkerObj;

            public Clinics()
            {
                dataworkerObj = new DataAcessClass.DataAcessClass.dataworker();
                Clinicsclientdataset = dataworkerObj.clientdataset;
            }


            public bool Dbconnset(bool connected)
            {
                if (connected)
                    dataworkerObj.openconn();
                else
                    dataworkerObj.closeconn();
                return connected;
            }


            public Int64 insertClinics(

                                                  string ClinicName,
                                                  string Depatrment,
                                                  string RoomNO,
                                                  int ClinicType,
                                                  string Comment
                                                 )
            {
                return dataworkerObj.generalinsert
                (
                " Clinics ",
                " ClinicName,Depatrment,RoomNO,ClinicType,Comment",
                "''" + ClinicName + "''" + " , " +
                "''" + Depatrment + "''" + " , " +
                "''" + RoomNO + "''" + " , " +
                ClinicType + " , " +
                "''" + Comment + "''"
                );
            }


            public int updateClinic(
                                            int ClinicCode,
                                            string ClinicName,
                                            string Depatrment,
                                            string RoomNO,
                                            int ClinicType,
                                            string Comment
                                            )
            {
                return dataworkerObj.generalupdate
                (
                " Clinics ",
                "ClinicName=''" + ClinicName + " , " +
                "Depatrment= ''" + Depatrment + "'' , " +
                "RoomNO= ''" + RoomNO + " , " +
                 "ClinicType= ''" + ClinicType.ToString() + " , " +
                "Comment= ''" + Comment + "'' "
                ,
                " ClinicCode= " + ClinicCode.ToString()
                );
            }

            public int deleteClinic(int ClinicCode)
            {
                return dataworkerObj.generalupdate
                (
                " Clinics ",
                " deleted=1 " ,
                " ClinicCode= " + ClinicCode.ToString()
                );
            }


            public bool findClinics(int ClinicCode)
            {
                return dataworkerObj.generalselect
                (
                " Clinics ",
                " * ",
                " ClinicCode= " + ClinicCode.ToString()
                );
            }

            public bool selectClinics(string fields, string conditon)
            {
                return dataworkerObj.generalselect
                 (
                 " Clinics ",
                 fields
                 ,
                 conditon
                 );

            }

            public bool selectjoinClinics(string fields, string conditon)
            {
                return dataworkerObj.generalJoinselect
                 (
                 " Clinics ",
                 fields
                 ,
                 conditon
                 ,
                 " clinicType"
                 );

            }

            public bool checkduplicateClinics(string clinicname)
            {
                return dataworkerObj.generalselect
                 (
                 " Clinics ",
                 "*",
                 "ClinicName"
                 );

            }


        }
        public class planvisit
        {
            public System.Data.SqlClient.SqlDataReader datasource;
            public System.Data.SqlClient.SqlCommand planvisitclientdataset;
            protected DataAcessClass.DataAcessClass.dataworker dataworkerObj;

            public planvisit()
            {
                dataworkerObj = new DataAcessClass.DataAcessClass.dataworker();
                planvisitclientdataset = dataworkerObj.clientdataset;
            }


            public bool Dbconnset(bool connected)
            {
                if (connected)
                    dataworkerObj.openconn();
                else
                    dataworkerObj.closeconn();
                return connected;
            }


            public Int64 insertplanvisit(

                                    int Doctorscode,
                                    int Cliniccode,
                                    int Capacity,
                                    string Fromdate,
                                    string todate,
                                    int Shiftcode,
                                    DateTime Fromtime,
                                    DateTime totime,
                                    int intervaltime,
                                    int usercode,
                                    string insertdate,
                                    int inserttime,
                                    string status,
                                    byte kind,
                                    int InternetCapacity
                                                 )
            {
                return dataworkerObj.generalinsert
                (
                " planvisit ",
                " Doctorscode,Cliniccode,Capacity,Fromdate,todate,Shiftcode,Fromtime,totime,intervaltime,usercode,insertdate,inserttime,status,kind,InternetCapacity",
                Doctorscode + " , " +
                Cliniccode + " , " +
                Capacity + " , " +
                "''" + Fromdate + "''" + " , " +
                "''" + todate + "''" + " , " +
               Shiftcode + " , " +
               Fromtime + " , " +
               totime + " , " +
               intervaltime + " , " +
               usercode + " , " +
                "''" + insertdate + "''" + " , " +
                inserttime + " , " +
                "''" + status + "''" + " , " +
                kind + " , " +
                InternetCapacity

                );
            }


            public int updateplanvisit(

                                    int planvisit_Code,
                                    int Doctorscode,
                                    int Cliniccode,
                                    int Capacity,
                                    string Fromdate,
                                    string todate,
                                    int Shiftcode,
                                    DateTime Fromtime,
                                    DateTime totime,
                                    int intervaltime,
                                    int usercode,
                                    string insertdate,
                                    int inserttime,
                                    string status,
                                    byte kind,
                                    int InternetCapacity
                                            )
            {
                return dataworkerObj.generalupdate
                (
                " planvisit ",
                "Doctorscode=''" + Doctorscode.ToString() + " , " +
                "Cliniccode= ''" + Cliniccode.ToString() + "'' , " +
                "Capacity= ''" + Capacity.ToString() + " , " +
                "Fromdate= ''" + Fromdate + " , " +
                "todate=''" + todate + " , " +
                "Shiftcode= ''" + Shiftcode.ToString() + "'' , " +
                "Fromtime= ''" + Fromtime.ToString() + " , " +
                "totime= ''" + totime.ToString() + " , " +
                "intervaltime=''" + intervaltime.ToString() + " , " +
                "usercode= ''" + usercode.ToString() + "'' , " +
                "insertdate= ''" + insertdate.ToString() + " , " +
                "inserttime= ''" + inserttime + " , " +
                "status= ''" + status + "'' " + " , " +
                kind + " , " +
                InternetCapacity
                ,
                " planvisit_Code= " + planvisit_Code.ToString()
                );
            }

            public int deleteplanvisit(int planvisitCode)
            {
                return dataworkerObj.generalupdate
                (
                " planvisit ",
                " Deleted=1 " ,
                " planvisit_Code= " + planvisitCode.ToString()
                );
            }


            public bool findplanvisit(int planvisitcode)
            {
                return dataworkerObj.generalselect
                (
                " planvisit ",
                " * ",
                " planvisit_Code= " + planvisitcode.ToString()
                );
            }

            public bool selectplanvisit(string workdate1, string workdate2)
            {
                string doctorsname,kindname;
                doctorsname = "persiantitle+" + "''" + " ''" + "+fname+" + "''" + " ''" + "+lname as doctorsname";
                kindname = " (case kind when 1 then "  +"''خدمات''" + " when 2 then "+  "''ویزیت''" + "when 3 then " +"''اسکرین''" + "end) as kindtext ";
                return dataworkerObj.generalselect_CTE
                 (
                   "planvisit",
                   "planvisit_Code, Doctorscode, Cliniccode, Capacity, Fromdate, Shiftcode, Fromtime, totime, intervaltime,kind " ,
                   "Fromdate between  " + "''" + workdate1 + "''" + "and " + "''" + workdate2 + "''" + " and deleted=0",
                   "planvisit_Code, Doctorscode, Cliniccode, Capacity, Fromdate, Shiftcode, Fromtime, totime, intervaltime, kind " ,
                   "planvisit_Code," + doctorsname + ",Clinics.ClinicName,Capacity,Fromdate,Shifts.Shiftname,GeneralTable.Fromtime, GeneralTable.totime, intervaltime," + kindname,
                   " left join Clinics ON GeneralTable.Cliniccode = Clinics.ClinicCode LEFT  JOIN  Shifts" +
                   " ON GeneralTable.Shiftcode = Shifts.Shiftcode LEFT  JOIN TblUsers ON GeneralTable.Doctorscode = TblUsers.UserCode",
                   " 1=1 "
                 );

            }

            public bool CheckDeleteplanvist(int planvisitcode)
            {
                return dataworkerObj.checkdeleteplanvist(planvisitcode);
            }

            public bool vacationinplanvisit(int doctorscode, string visitdate)
            {
                return dataworkerObj.vacationinplanvisit(doctorscode, visitdate);
            }

            public bool Duplicateinplanvisit(int doctorscode, string visitdate, TimeSpan fromtime, TimeSpan totime,int kind)
            {
                return dataworkerObj.Duplicateinplanvisit(doctorscode, visitdate, fromtime, totime,kind);
            }

            public bool Duplicateineditplanvisit(int doctorscode, string visitdate, TimeSpan fromtime, TimeSpan totime,int kind, int planvisitcode)
            {
                return dataworkerObj.Duplicateineditplanvisit(doctorscode, visitdate, fromtime, totime, kind, planvisitcode);
            }

            public bool selectclinicinplanvisit(string fields, string conditon)
            {
                return dataworkerObj.generalselect
                  (
                  " planvisit ",
                  fields
                  ,
                  conditon
                  );

            }

            public bool selectplanvisit(string fromdate, byte shiftcode,byte kind)
            {
                return dataworkerObj.selectplanvisit(fromdate, shiftcode,kind);
            }

            public bool selectdentaltooth(int ToothID)
            {
                return dataworkerObj.generalselect(
                    "Dent_Tooth",
                    "ToothImage",
                    "ToothID=" + ToothID
                    );
            }
        }

        public class Doctorsworktime
        {
            public System.Data.SqlClient.SqlDataReader datasource;
            public System.Data.SqlClient.SqlCommand Doctorsworktimeclientdataset;
            protected DataAcessClass.DataAcessClass.dataworker dataworkerObj;

            public Doctorsworktime()
            {
                dataworkerObj = new DataAcessClass.DataAcessClass.dataworker();
                Doctorsworktimeclientdataset = dataworkerObj.clientdataset;
            }


            public bool Dbconnset(bool connected)
            {
                if (connected)
                    dataworkerObj.openconn();
                else
                    dataworkerObj.closeconn();
                return connected;
            }

            public DateTime shamsitomiladi(string shamsidate)
            {
                return dataworkerObj.shamsitomiladi(shamsidate);
            }

            public string miladitoshamsi(DateTime miladidate)
            {
                return dataworkerObj.miladitoshamsi(miladidate);
            }

            public DateTime getdate()
            {
                return dataworkerObj.getdate();
            }
            public int deleteDoctorsworktime(int DoctorsworktimeCode)
            {
                return dataworkerObj.generalupdate
                (
                " Doctorsworktime ",
                " deleted = 1 " ,
                " DoctorsworktimeCode= " + DoctorsworktimeCode.ToString()
                );
            }

            public bool selectDoctorsworktime(string workdate1, string workdate2)
            {
                string doctorsname;
                doctorsname = "persiantitle+" + "''" + " ''" + "+fname+" + "''" + " ''" + "+lname as doctorsname";
                return dataworkerObj.generalselect_CTE
                 (
                 "Doctorsworktime",
                 "DoctorsWorkTimeCode, Doctorscode, Workdate, Workdate_eng, Workshift, timeFrom, timeTo, Kind",
                 "workdate between  " + "''" + workdate1 + "''" + "and " + "''" + workdate2 + "''"+ " and deleted=0",
                 "DoctorsWorkTimeCode, Doctorscode, Workdate, Workdate_eng, Workshift, timeFrom, timeTo, Kind",
                 "DoctorsWorkTimeCode," + doctorsname + ",Workdate,shiftname,timefrom,timeto,kind ",
                 " left join tblusers on GeneralTable.doctorscode=tblusers.usercode left join shifts on workshift=shiftcode ",
                 " 1=1"

                 );

            }
        }
        public class ContractoutCenter
        {
            public System.Data.SqlClient.SqlDataReader datasource;
            public System.Data.SqlClient.SqlCommand ContractoutCenterclientdataset;
            protected DataAcessClass.DataAcessClass.dataworker dataworkerObj;

            public ContractoutCenter()
            {
                dataworkerObj = new DataAcessClass.DataAcessClass.dataworker();
                ContractoutCenterclientdataset = dataworkerObj.clientdataset;
            }


            public bool Dbconnset(bool connected)
            {
                if (connected)
                    dataworkerObj.openconn();
                else
                    dataworkerObj.closeconn();
                return connected;
            }

            public int deleteContractoutCenter(int outCenterCode)
            {
                return dataworkerObj.generalupdate
                (
                " outcenter ",
                " deleted = 1" ,
                " outCenterCode= " + outCenterCode.ToString()
                );
            }

            public bool selectContractoutCenter()
            {

                return dataworkerObj.generalselect
                 (
                 "  outcenter left  JOIN   OutCenterdepartment ON outcenter.OutCenterdepartment = OutCenterdepartment.OutCenterDepartmentCode left  JOIN  outcenterKind ON outcenter.outcenterKind = outcenterKind.outcenterKindCode "
                 ,
                 "  outcenter.outcenterCode, outcenter.outcenterName, outcenterKind.kindDesc, OutCenterdepartment.departmentDesc, outcenter.beginDate, outcenter.Enddate,outcenter.Status"
                 ,
                 " deleted = 0 "
                 );

            }
        }
        public class vacations
        {
            public System.Data.SqlClient.SqlDataReader datasource;
            public System.Data.SqlClient.SqlCommand vacationsclientdataset;
            protected DataAcessClass.DataAcessClass.dataworker dataworkerObj;

            public vacations()
            {
                dataworkerObj = new DataAcessClass.DataAcessClass.dataworker();
                vacationsclientdataset = dataworkerObj.clientdataset;
            }


            public bool Dbconnset(bool connected)
            {
                if (connected)
                    dataworkerObj.openconn();
                else
                    dataworkerObj.closeconn();
                return connected;
            }

            public int deletevacations(int vacationsCode)
            {
                return dataworkerObj.generalupdate
                (
                " vacations ",
                " deleted = 1 ",
                " vacationsCode= " + vacationsCode.ToString()
                );
            }

            public bool selectvacations(string workdate1, string workdate2)
            {

                string doctorsname;
                doctorsname = "persiantitle+" + "''" + " ''" + "+fname+" + "''" + " ''" + "+lname as doctorsname";
                return dataworkerObj.generalselect
                 (
                 " vacations left join tblusers on vacations.doctorscode=tblusers.usercode"
                 ,
                 " vacationsCode," + doctorsname + ",vacationType,fromDate,Todate"
                 ,
                "  deleted = 0  and  fromdate between  " + "''" + workdate1 + "''" + "and " + "''" + workdate2 + "''"
                 );

            }
            public bool checkduplicatevacations(int doctorscode, string fromdate, string todate)
            {
                return dataworkerObj.checkduplicatevacations(doctorscode, fromdate, todate);

            }
        }

        public class tariffs
        {
            public System.Data.SqlClient.SqlDataReader datasource;
            public System.Data.SqlClient.SqlCommand tariffsclientdataset;
            protected DataAcessClass.DataAcessClass.dataworker dataworkerObj;

            public tariffs()
            {
                dataworkerObj = new DataAcessClass.DataAcessClass.dataworker();
                tariffsclientdataset = dataworkerObj.clientdataset;
            }


            public bool Dbconnset(bool connected)
            {
                if (connected)
                    dataworkerObj.openconn();
                else
                    dataworkerObj.closeconn();
                return connected;
            }

            public int deletetariffs(int Tariffcode)
            {
                return dataworkerObj.generalupdate
                (
                " tariff ",
                " deleted = 1" ,
                " Tariffcode= " + Tariffcode.ToString()
                );
            }

            public bool selecttariffs(int year)
            {


                return dataworkerObj.generalselect
                 (
                 " tariff LEFT  JOIN  TblEmployeetype ON tariff.Kindpaient = TblEmployeetype.id LEFT JOIN TblCompany ON tariff.Kindjobpaient_managment = TblCompany.id and tariff.Kindjobpaient_company=TblCompany.TblManagement_Id"
                 ,
                 "  tariff.Tariffcode,tariff.tariffkind, tariff.TariffBegindate, tariff.Tariffenddate, tariff.Zarib, TblEmployeetype.EmployeeTypeDesc,TblCompany.Description,tariff.year,tariff.feranshiz"
                 ,
                "  deleted=0 and  year = " + year
                 );

            }


            public bool selecttariffs(int year,int tariffkind)
            {


                return dataworkerObj.generalselect
                 (
                 " tariff "
                 ,
                 "  * "
                 ,
                " year = " + year + " and Tariffkind_int = " + tariffkind
                 );

            }


            public bool selecttariffcash(int year, int Kindpaient)
            {


                return dataworkerObj.generalselect
                 (
                 " tariff "
                 ,
                 "  * "
                 ,
                " year = " + year + " and Kindpaient = " + Kindpaient
                 );

            }
        }


        public class Services
        {
            public System.Data.SqlClient.SqlDataReader datasource;
            public System.Data.SqlClient.SqlCommand Servicesclientdataset;
            protected DataAcessClass.DataAcessClass.dataworker dataworkerObj;

            public Services()
            {
                dataworkerObj = new DataAcessClass.DataAcessClass.dataworker();
                Servicesclientdataset = dataworkerObj.clientdataset;
            }


            public bool Dbconnset(bool connected)
            {
                if (connected)
                    dataworkerObj.openconn();
                else
                    dataworkerObj.closeconn();
                return connected;
            }

            public int deleteServices(int Services_detail_Code)
            {
                return dataworkerObj.generalupdate
                (
                " Services_detail ",
                " deleted = 1 " ,
                " Services_detail_Code = " + Services_detail_Code.ToString()
                );
            }

            public int deleteServicestypeF16(int ServiceTypeF16Code)
            {
                return dataworkerObj.generalupdate
                (
                " ServiceTypeF16 ",
                " deleted = 1" ,
                " ServiceTypeF16Code = " + ServiceTypeF16Code.ToString()
                );
            }

            public int deleteServicestypeKanoon(int ServiceTypeF16Code)
            {
                return dataworkerObj.generalupdate
                (
                " ServiceTypeKanoon ",
                " deleted = 1",
                " ServiceTypeKanoonCode = " + ServiceTypeF16Code.ToString()
                );
            }

            public int deleteServicestypeScreen(int ServiceTypeF16Code)
            {
                return dataworkerObj.generalupdate
                (
                " ServiceTypeScreen ",
                " deleted = 1",
                " ServiceTypeScreenCode = " + ServiceTypeF16Code.ToString()
                );
            }

            public bool selectServices()
            {


                return dataworkerObj.generalJoinselect
                 (
                 "Services_Head ",
                 " Services_detail_Code,Services_Head.Services_Head_name, Services_detail.Services_detail_Name, K_NO,Kanal_NO, Pinaj_NO, Pinkanal_NO, Pinamalgam_NO, Pinkampozit_NO,ISValid "
                 ,
                 "  Services_detail.deleted=0 "
                 ,
                 " Services_detail ON Services_Head.Services_Head_code = Services_detail.Services_Head_code "
                 );

            }

            public bool selectInsServices()
            {


                return dataworkerObj.generalselect
                 (
                 "Services_detail ",
                 " Services_detail_Code,Services_detail.Services_detail_Name"
                 ,
                 " isvalid=1  order by Services_detail_Name "
                 );

            }

            public Int64 insert_servicesgroup_report(string Services_Group_Desc_report)
            {
                 return dataworkerObj.generalinsert(
                     "Services_Group_report",
                     "Services_Group_Desc_report",
                     "''" + Services_Group_Desc_report + "''" 
                     );
            }


            public Int64 insert_servicesgroup_detail_report(Int64 Services_Group_code_report,string ServicesCode)
            {
                 return dataworkerObj.generalinsert(
                     "Services_Group_detail_report",
                     "Services_Group_code_report,ServicesCode",
                     Services_Group_code_report +"," + ServicesCode
                     );
            }




            public bool selectInsServices_cost()
            {


                return dataworkerObj.generalselect
                 (
                 "Services_detail ",
                 " Services_detail_Code,Services_detail.Services_detail_Name"
                 ,
                 " 1=1 order by Services_detail_Name "
                 );

            }

            public bool selectRadioInsServices()
            {


                return dataworkerObj.generalselect
                 (
                 "Radio_services ",
                 " ServicesCode,English_Name,code"
                 ,
                 " 1=1  order by code "
                 );

            }

            public bool serviceshistory(int fkvdfamily, string visitdate)
            {
                return dataworkerObj.serviceshistory(fkvdfamily, visitdate);
            }

            public bool servicesRadiohistory(int fkvdfamily, string visitdate)
            {
                return dataworkerObj.servicesRadiohistory(fkvdfamily, visitdate);
            }


            public bool InternalServicesHistory(int fkvdfamily, string turndate1, string turndate2)
            {
                return dataworkerObj.InternalServicesHistory(fkvdfamily, turndate1, turndate2);
            }

            public bool InternalServicesHistoryfull(int fkvdfamily, string turndate1, string turndate2)
            {
                return dataworkerObj.InternalServicesHistoryfull(fkvdfamily, turndate1, turndate2);
            }


            public bool Internal_detailServicesHistory(int recipeid)
            {
                return dataworkerObj.Internal_detailServicesHistory(recipeid);
            }


                public bool Services_Group_view_h()
            {
                return dataworkerObj.Services_Group_view_h();
            }

                public bool Services_Group_view_d(int groupcode)
                {
                    return dataworkerObj.Services_Group_view_d(groupcode);
                }


                public int deleteServices_Group_report(int Services_Group_code_report)
                {
                    return dataworkerObj.generalupdate
                    (
                    " Services_Group_report ",
                     "deleted=1",
                    " Services_Group_code_report= " + Services_Group_code_report
                    );

                }

        }

        public class CostConfirm
        {
            public System.Data.SqlClient.SqlDataReader datasource;
            public System.Data.SqlClient.SqlCommand CostConfirmclientdataset;
            protected DataAcessClass.DataAcessClass.dataworker dataworkerObj;

            public CostConfirm()
            {
                dataworkerObj = new DataAcessClass.DataAcessClass.dataworker();
                CostConfirmclientdataset = dataworkerObj.clientdataset;
            }


            public bool Dbconnset(bool connected)
            {
                if (connected)
                    dataworkerObj.openconn();
                else
                    dataworkerObj.closeconn();
                return connected;
            }

            public int deleteCostConfirm_head(int costconfirmheadCode)
            {
                return dataworkerObj.generalupdate
                (
                " CostConfirm_head ",
                  "deleted=1",
                " costconfirmCode= " + costconfirmheadCode.ToString()
                );
            }
            public int deleteCostConfirm_detail(int costconfirmheadCode)
            {
                return dataworkerObj.generalupdate
                (
                " CostConfirm_detail ",
                  "deleted=1",
                " costconfirmHeadCode= " + costconfirmheadCode.ToString()
                );
            }

            public bool selectCostConfirm(int fkvdfamily, string Confirmdate)
            {

                return dataworkerObj.selectCostConfirm(fkvdfamily, Confirmdate);

            }


            public bool selectCostConfirm_head(string startdate, string enddate)
            {

                return dataworkerObj.selectCostConfirm_head(startdate, enddate);

            }


            public bool selectCostConfirm_detail(int costconfirmHeadCode)
            {

                return dataworkerObj.selectCostConfirm_detail(costconfirmHeadCode);

            }


            public Int64 InsertCostconfirm_head(

                                         string Idperson,
                                         int Persno,
                                         int Fkvdfamily,
                                         string VisitDate,
                                         string Doctorsoutname,
                                         string Confirmdate,
                                         string Confirmtime,
                                         int Doctorscode,
                                         int usercode,
                                         string ipadress

                                        )
            {
                return dataworkerObj.generalinsert
                (
                " costconfirm_head ",

                " Idperson,Persno,Fkvdfamily,VisitDate,Doctorsoutname,Confirmdate,Confirmtime,Doctorscode ,usercode ,ipadress",

                 "''" + Idperson + "''" + " , " +
                Persno + " , " +
                 Fkvdfamily + " , " +
                 "''" + VisitDate + "''" + " , " +
                  "''" + Doctorsoutname + "''" + " , " +
                 "''" + Confirmdate + "''" + " , " +
                 "''" + Confirmtime + "''" + " , " +
                 Doctorscode + " , " +
                 usercode + " , " +
                 "''" + ipadress + "''"

                );
            }

            public Int64 InsertCostconfirm_Detail(
                                         Int64 costconfirmHeadCode,
                                          int Servicescode,
                                          byte ToothID
                                     )
            {
                return dataworkerObj.generalinsert
              (
              " costconfirm_Detail ",
              " costconfirmHeadCode,Servicescode,ToothID",
               costconfirmHeadCode + " , " +
               Servicescode + " , " +
               ToothID

              );
            }



        }

        public class persontbl
        {
            public System.Data.SqlClient.SqlDataReader datasource;
            public System.Data.SqlClient.SqlCommand persontblclientdataset;
            protected DataAcessClass.DataAcessClass.dataworker dataworkerObj;
            public persontbl()
            {
                dataworkerObj = new DataAcessClass.DataAcessClass.dataworker();
                persontblclientdataset = dataworkerObj.clientdataset;
            }


            public bool Dbconnset(bool connected)
            {
                if (connected)
                    dataworkerObj.openconn();
                else
                    dataworkerObj.closeconn();
                return connected;
            }



            public bool selectpersontbl(int persno)
            {


                return dataworkerObj.selectpersontbl(persno);


            }

            public bool selectpersontblvdfamily(int fkvdfamily)
            {


                return dataworkerObj.selectpersontblpkvdfamily(fkvdfamily);

            }

            public bool checkEmployeeinfotbl(int persno)
            {
                return dataworkerObj.generalselect("EmployeeInfoTbl", "*", "Persno = " + persno.ToString());
            }

            public bool selectpersno(string NationalCode)
            {
                return dataworkerObj.generalselect("PersonTbl", "NationalCode", "NationalCode = " + NationalCode);
            }

            public bool selectpersno_p(string persno, int fk_nesbat)
            {
                return dataworkerObj.generalselect("PersonTbl", "persno", "persno = " + persno + " and TblRelation_Id=" + fk_nesbat.ToString());
            }

            public bool serach(string searchstr)
            {
                return dataworkerObj.generalselect_CTE("persontbl", "PersNo,NationalCode,FName,LName,BirthDate,tblrelation_id,EmployeeInfoTbl_Id,TblValidCenterCity_Id", searchstr, "PersNo,NationalCode,FName,LName,BirthDate,tblrelation_id,EmployeeInfoTbl_Id,TblValidCenterCity_Id", "GeneralTable.PersNo,NationalCode,FName,LName,BirthDate,tblrelation.Description,EmployeeTypeDesc,tblValidCenterCity.Description", "left join EmployeeInfoTbl ON generaltable.EmployeeInfoTbl_Id = EmployeeInfoTbl.Id left join  TblRelation on tblrelation_id= TblRelation.id  left join  TblEmployeetype ON EmployeeInfoTbl.TblEmployeetype_Id = TblEmployeetype.Id left join  TblValidCenterCity ON GeneralTable.TblValidCenterCity_Id = tblValidCenterCity.Id", "1=1");
            }


   
        }

        public class introductions
        {
            public System.Data.SqlClient.SqlDataReader datasource;
            public System.Data.SqlClient.SqlCommand introductionsclientdataset;
            protected DataAcessClass.DataAcessClass.dataworker dataworkerObj;

            public introductions()
            {
                dataworkerObj = new DataAcessClass.DataAcessClass.dataworker();
                introductionsclientdataset = dataworkerObj.clientdataset;
            }


            public bool Dbconnset(bool connected)
            {
                if (connected)
                    dataworkerObj.openconn();
                else
                    dataworkerObj.closeconn();
                return connected;
            }


            public bool selectcommnet()
            {
                return dataworkerObj.generalselect("Introduction_Comment", "*", "1=1 order by id");
            }

            public bool selectIntroductioncommnet(int CommentCode)
            {
                return dataworkerObj.generalselect("IntroductionComment", "*", "CommentCode =" + CommentCode + "and deleted=0");
            }


            public bool selectIntroductionsServices()
            {


                return dataworkerObj.generalselect
                 (
                 "ServiceTypeIntroduction ",
                 " ServiceId,Servicename",
                 " Status=1 "
                 );

            }

            public int deleteComment(int Commentid)
            {
                return dataworkerObj.generalupdate
                (
                " Introduction_Comment ",
                " deleted = 1" ,
                " id= " + Commentid
                );

            }

            public bool selectIntroductioncommnet()
            {
                return dataworkerObj.generalselect("Comment", "*", "1=1 order by id");
            }
            public bool introduction_Headselect(string startdate, string enddate)
            {

                return dataworkerObj.introduction_Headselect(startdate, enddate);

            }

            public bool selectintroduction_detail(int introductioncode)
            {

                return dataworkerObj.introduction_Detailselect(introductioncode);

            }

            public bool introductionsselect_persno(int persno)
            {

                return dataworkerObj.introductionselect_persno(persno);

            }

            public int deleteIntroduction(int introductioncode)
            {
                return dataworkerObj.generalupdate
                (
                " introduction_head ",
                 "deleted=1",
                " introductioncode= " + introductioncode
                );

            }

            public int deleteIntroduction_detail(int introductioncode)
            {
                return dataworkerObj.generalupdate
                (
                " introduction_detail ",
                 "deleted=1",
                " introductionheadcode= " + introductioncode
                );

            }

            public int deleteIntroductionComment(int introductioncode)
            {
                return dataworkerObj.generalupdate
                   (
               " IntroductionComment ",
                 "deleted=1",
               " introductioncode= " + introductioncode
               );

            }

            public Int64 Insertintroduction_head(

                                             string Idperson,
                                             int Persno,
                                             int Fkvdfamily,
                                             string Personalcode,
                                             int Outcentercode,
                                             string introductionDate,
                                             string introductionTime,
                                             int Doctorscode,
                                             int introductionkind,
                                             int usercode,
                                             Int32 TurnId,
                                             string ipadress

                                            )
            {
                return dataworkerObj.generalinsert
                (
                " introduction_Head ",
                " Idperson,Persno,Fkvdfamily,Personalcode,Outcentercode,introductionDate ,introductionTime ,Doctorscode ,introductionkind,usercode,TurnId,ipadress",
                 "''" + Idperson + "''" + " , " +
                Persno + " , " +
                 Fkvdfamily + " , " +
                 "''" + Personalcode + "''" + " , " +
                 Outcentercode + " , " +
                 "''" + introductionDate + "''" + " , " +
                 "''" + introductionTime + "''" + " , " +
                 Doctorscode + " , " +
                introductionkind + " , " +
                 usercode + " , " +
                 TurnId + " , " +
                 "''" + ipadress + "''"

                );
            }


            public Int64 Insertintroduction_Detail(
                                       Int64 introductionHeadCode,
                                        int Servicescode,
                                        byte ToothID1,
                                        byte ToothID2,
                                        byte ToothID3,
                                        byte ToothID4,
                                        byte ToothID5
                                       
                                   )
            {
                return dataworkerObj.generalinsert
              (
              " introduction_Detail ",
              " introductionHeadCode,Servicescode,ToothID1,ToothID2,ToothID3,ToothID4,ToothID5",
               introductionHeadCode + " , " +
               Servicescode + " , " +
               ToothID1+ " , " +
               ToothID2+ " , " +
               ToothID3+ " , " +
               ToothID4+ " , " +
               ToothID5
                
              );
            }

            public Int64 InsertIntroductionComment(
                                         Int64 Introductioncode,
                                          int CommentCode
                                     )
            {
                return dataworkerObj.generalinsert
              (
              " IntroductionComment ",
              " Introductioncode,CommentCode",
               Introductioncode + " , " +
               CommentCode

              );
            }


            public bool introductionprint(Int64 introductioncode)
            {


                return dataworkerObj.introductionprint(introductioncode);


            }


            public bool Introductioncommentprint(Int64 introductioncode)
            {


                return dataworkerObj.Introductioncommentprint(introductioncode);


            }

            public bool report1(string startdate, string enddate)
            {
                return dataworkerObj.report1(startdate, enddate);
            }


            public bool report2(string startdate, string enddate)
            {
                return dataworkerObj.report2(startdate, enddate);
            }

        }

        public class Recipe
        {

            public string conectionstring;
            public System.Data.SqlClient.SqlDataReader datasource;
            public System.Data.SqlClient.SqlCommand Recipeclientdataset;
            protected DataAcessClass.DataAcessClass.dataworker dataworkerObj;

            public int GroupIdentityNumber;
            public int FileIdentityNumber;

            public Recipe()
            {
                dataworkerObj = new DataAcessClass.DataAcessClass.dataworker();
                Recipeclientdataset = dataworkerObj.clientdataset;
                conectionstring = dataworkerObj.conectionstring;
            }


            public bool Dbconnset(bool connected)
            {
                if (connected)
                    dataworkerObj.openconn();
                else
                    dataworkerObj.closeconn();
                return connected;
            }

            public Int64 Insertrecipe(

                                            string Idperson,
                                            int persno,
                                            string Personelcode,
                                            int Fkvdfamily,
                                            string Currentdate,
                                            string currentTime,
                                            string Turndate,
                                            string Turntime,
                                            byte turnNo,
                                            int DoctorsCode,
                                            int Planvisit_code,
                                            int Servicescode,
                                            byte TurnStatus,
                                            byte Shiftcode,
                                            byte ToothID,
                                            byte PaientType,
                                            byte PaientStatus,
                                            int Usercode,
                                            byte recipekind,
                                            string ipadress,
                                            int  validcenterzone,
                                            int validcenter,
                                            int relationorderno,
                                            int  specialityKindCode,
                                            int age
                                           )
            {
                return dataworkerObj.generalinsert
                (
                " recipe ",
                " Idperson,persno,Personelcode,Fkvdfamily,Currentdate,currentTime,Turndate,Turntime,turnNo ,DoctorsCode ,Planvisit_code ,Servicescode ,TurnStatus ,Shiftcode,ToothID,PaientType,PaientStatus,Usercode,recipekind,ipadress,validcenterzone,validcenter,relationorderno,specialityKindCode,age",
                "''" + Idperson + "''" + " , " +
                persno + " , " +
                "''" + Personelcode + "''" + " , " +
                 Fkvdfamily + " , " +
                 "''" + Currentdate + "''" + " , " +
                 "''" + currentTime + "''" + " , " +
                 "''" + Turndate + "''" + " , " +
                 "''" + Turntime + "''" + " , " +
                 turnNo + " , " +
                 DoctorsCode + " , " +
                 Planvisit_code + " , " +
                 Servicescode + " , " +
                 TurnStatus + " , " +
                 Shiftcode + " , " +
                 ToothID + " , " +
                 PaientType + " , " +
                 PaientStatus + " , " +
                 Usercode + " , " +
                 recipekind + " , " +
                 "''" + ipadress + "''" + " , " +
                 validcenterzone + " , " +
                 validcenter + " , " +
                 relationorderno + " , " +
                 specialityKindCode+ " , " +
                 age
                );
            }

            public string recipetime(TimeSpan starttime, byte intervaltime, byte turnno)
            {
                int p1, p2, p3, h, m;
                string temprecipetime;
                string h1 = "", m1 = "";
                p1 = intervaltime * (turnno-1);
                p2 = p1 / 60;
                p3 = p1 % 60;
                h = starttime.Hours + p2;
                m = starttime.Minutes + p3;
       
                if (m>=60)
                {
                    h=h+1;
                    m = m - 60;
                }
                    
                if (m < 10)
                    m1 =  "0" + m.ToString() ;

                else if (m >= 10)
                    m1 = m.ToString();

                if (h < 10)
                    h1 = "0" + h.ToString();
                else if (h >= 10)
                    h1 = h.ToString();

                temprecipetime = h1 + ":" + m1;
                return temprecipetime;
            }


            public string selectRecipeError(int fkvdfamily)
            {

                return dataworkerObj.selectRecipeError(fkvdfamily);

            }


            public string checkFkvdfamilyRecipe(int fkvdfamily, int personalcode, string datet, int code, out string tdate, out string doctorsname)
            {
                return dataworkerObj.checkFkvdfamilyRecipe(fkvdfamily, personalcode,datet, code,out tdate,out doctorsname);
            }


            public byte selectcountRecipe(int Planvisit_code)
            {
                return dataworkerObj.selectcountRecipe(Planvisit_code);
            }


            public bool selectturnno(int Planvisit_code)
            {
                return dataworkerObj.selectTurnno(Planvisit_code);
            }

            public bool CheckDuplicateTurnno(int Planvisit_code, byte turnno)
            {
                return dataworkerObj.CheckDuplicateTurnno(Planvisit_code, turnno);
            }

            public bool selectPaientList(int doctorscode, string turndate, byte statuscode, byte kind)
            {
                return dataworkerObj.selectPaientList(doctorscode, turndate, statuscode,kind);
            }


            public Int64 InsertdoctorsService(

                                          string Idperson,
                                          int Persno,
                                          int Fkvdfamily,
                                          int Servicescode,
                                          byte ToothID,
                                          int Doctorscode,
                                          Int64 Planvst,
                                          int Recipeturn,
                                          Int64 recipeID,
                                          byte Status,
                                          int Usercode,
                                          string Insertdate,
                                          string Inserttime,
                                          string ipadress



                                         )
            {
                return dataworkerObj.generalinsert
                (
                " doctorsService ",
                " Idperson,Persno,Fkvdfamily,Servicescode,ToothID,Doctorscode,Planvst ,Recipeturn ,recipeID ,Status ,Usercode ,Insertdate,Inserttime,ipadress",
                "''" + Idperson + "''" + " , " +
                Persno + " , " +
                 Fkvdfamily + " , " +
                 Servicescode + " , " +
                 ToothID + " , " +
                 Doctorscode + " , " +
                 Planvst + " , " +
                 Recipeturn + " , " +
                 recipeID + " , " +
                 Status + " , " +
                 Usercode + " , " +
                 "''" + Insertdate + "''" + " , " +
                 "''" + Inserttime + "''" + " , " +
                 "''" + ipadress + "''"

                );
            }



            public Int64 insertRadio_Services_request(

                                       string Idperson,
                                       int Persno,
                                       int Fkvdfamily,
                                       string Currentdate,
                                       string currentTime,
                                       int DoctorsCode,
                                       int validcenterzone,
                                       byte Status1,
                                       byte Status2,
                                       int Usercode,                                       
                                       string ipadress

                                      )
            {
                return dataworkerObj.generalinsert
                (
                " Radio_Services_request ",
                " Idperson,Persno,Fkvdfamily,Currentdate,currentTime,Doctorscode,validcenterzone ,Status1,status2 ,Usercode ,ipadress",
                "''" + Idperson + "''" + " , " +
                 Persno + " , " +
                 Fkvdfamily + " , " +
                 "''" + Currentdate + "''" + " , " +
                 "''" + currentTime + "''" + " , " +
                 DoctorsCode + " , " +
                 validcenterzone + " , " +
                 Status1 + " , " +
                 Status2 + " , " +
                 Usercode + " , " +
                 "''" + ipadress + "''"

                );
            }


            public Int64 insertRadio_Services_request_Detail(

                                  Int64 Radio_Services_request_code,
                                  byte Radio_services_Code,
                                  int ServicesCode,
                                  int ToothId,
                                  byte Area,
                                  byte Status
                                 )
            {
                return dataworkerObj.generalinsert
                (
                " Radio_Services_request_Detail ",
                " Radio_Services_request_code,Radio_services_Code,ServicesCode,ToothId,Area,Status",
                 Radio_Services_request_code + " , " +
                 Radio_services_Code + " , " +
                 ServicesCode + " , " +
                 ToothId + " , " +
                 Area + " , " +
                 Status 
                );
            }



            public int deletedoctorsService(int doctorsServicecode)
            {
                return dataworkerObj.generalupdate
                (
                " doctorsService ",
                "deleted=1",
                " doctorsServiceCode = " + doctorsServicecode.ToString()
                );
            }


            public int deleteradioRequestService(int code)
            {
                return dataworkerObj.generalupdate
                (
                " Radio_Services_request_Detail ",
                "deleted=1",
                " code = " + code.ToString()
                );
            }

            public int ChangeStatus_recipe(Int64 turnid, byte statuscode)
            {
                return dataworkerObj.generalupdate("recipe", "TurnStatus=" + statuscode, "turnid=" + turnid);
            }

            public bool DoctorsCountPaient(string startdate, string enddate)
            {

                return dataworkerObj.DoctorsCountPaient(startdate, enddate);

            }

            public  int changeNOnPaientReferStatus(string enddate)
            {
                return dataworkerObj.generalupdate(
                    "recipe", 
                    "TurnStatus=3", 
                    "turnstatus=1 and turndate < " + "''" + enddate  + "'' "
                    );
            }

            public bool checkpersoninfotbl(int persno)
            {
                return dataworkerObj.generalselect("PersonInfo", "*", "persno = " + persno.ToString());
            }

            public bool checkEmployeeinfotbl(int persno)
            {
                return dataworkerObj.generalselect("EmployeeInfoTbl", "*", "Persno = " + persno.ToString());
            }

            public bool SelectPhoneNo(int persno)
            {
                return dataworkerObj.generalselect("persontbl", "", "persno = " + persno.ToString());
            }

            public int UpdatePhoneNo(int fkvdfamily,string phone)
            {
                return dataworkerObj.generalupdate("persontbl", "mobile = " + "''" + phone + "''", "pk_vdfamily = " + fkvdfamily.ToString());
            }

            public bool selectpersno(string NationalCode)
            {
                return dataworkerObj.generalselect("PersonTbl", "NationalCode", "NationalCode = " + NationalCode);
            }


            public bool selectpersno_p(string persno,int fk_nesbat)
            {
                return dataworkerObj.generalselect("PersonTbl", "persno", "persno = " + persno + " and  TblRelation_Id =" + fk_nesbat.ToString());
            }

        }
        
        public class medicalrest
        {

            public string conectionstring;
            public System.Data.SqlClient.SqlDataReader datasource;
            public System.Data.SqlClient.SqlCommand medicalrestlientdataset;
            protected DataAcessClass.DataAcessClass.dataworker dataworkerObj;

            public int GroupIdentityNumber;
            public int FileIdentityNumber;

            public medicalrest()
            {
                dataworkerObj = new DataAcessClass.DataAcessClass.dataworker();
                medicalrestlientdataset = dataworkerObj.clientdataset;
                conectionstring = dataworkerObj.conectionstring;
            }


            public bool Dbconnset(bool connected)
            {
                if (connected)
                    dataworkerObj.openconn();
                else
                    dataworkerObj.closeconn();
                return connected;
            }


            public bool medicalrestselect(string startdate, string enddate)
            {

                return dataworkerObj.medicalrestselect(startdate, enddate);

            }

            public bool medicalrestselect_persno(int persno)
            {

                return dataworkerObj.medicalrestselect_persno(persno);

            }

            public int deletemedicalrest(int medicalrestcode)
            {
                return dataworkerObj.generalupdate
                (
                " Medicalrest ",
                " deleted = 1" ,
                " MedicalrestCode = " + medicalrestcode.ToString()
                );
            }



        }


        public class consult
        {

            public string conectionstring;
            public System.Data.SqlClient.SqlDataReader datasource;
            public System.Data.SqlClient.SqlCommand Consultclientdataset;
            protected DataAcessClass.DataAcessClass.dataworker dataworkerObj;

            public int GroupIdentityNumber;
            public int FileIdentityNumber;

            public consult()
            {
                dataworkerObj = new DataAcessClass.DataAcessClass.dataworker();
                Consultclientdataset = dataworkerObj.clientdataset;
                conectionstring = dataworkerObj.conectionstring;
            }


            public bool Dbconnset(bool connected)
            {
                if (connected)
                    dataworkerObj.openconn();
                else
                    dataworkerObj.closeconn();
                return connected;
            }


            public bool Consultselect(string startdate, string enddate)
            {

                return dataworkerObj.Consultselect(startdate, enddate);

            }

            public bool Consultselect_persno(int persno)
            {

                return dataworkerObj.Consultselect_persno(persno);

            }

            public int deleteconsult(int consultcode)
            {
                return dataworkerObj.generalupdate
                (
                " consult ",
                " deleted =1" ,
                " ConsultCode = " + consultcode.ToString()
                );
            }



        }


        public class Screen
        {

            public string conectionstring;
            public System.Data.SqlClient.SqlDataReader datasource;
            public System.Data.SqlClient.SqlCommand Screenclientdataset;
            protected DataAcessClass.DataAcessClass.dataworker dataworkerObj;

            public int GroupIdentityNumber;
            public int FileIdentityNumber;

            public Screen()
            {
                dataworkerObj = new DataAcessClass.DataAcessClass.dataworker();
                Screenclientdataset = dataworkerObj.clientdataset;
                conectionstring = dataworkerObj.conectionstring;
            }


            public bool Dbconnset(bool connected)
            {
                if (connected)
                    dataworkerObj.openconn();
                else
                    dataworkerObj.closeconn();
                return connected;
            }

            public bool selectdent_screen2(int fkvdfamily)
            {
                return dataworkerObj.generalselect("dent_screen2", "*", "fk_vdfamily =" + fkvdfamily.ToString());
            }

            public bool selectChiefcomplain(int fkvdfamily)
            {

                return dataworkerObj.selectChiefcomplain(fkvdfamily);

            }

            public bool selectGraphy_comment(int fkvdfamily)
            {

                return dataworkerObj.selectGraphy_comment(fkvdfamily);

            }

            public bool selectRestorativeTx_Comment(int fkvdfamily)
            {

                return dataworkerObj.selectRestorativeTx_Comment(fkvdfamily);

            }

            public bool selectRCT_Comment(int fkvdfamily)
            {

                return dataworkerObj.selectRCT_Comment(fkvdfamily);

            }

            public bool selectExt_Sx_Comment(int fkvdfamily)
            {

                return dataworkerObj.selectExt_Sx_Comment(fkvdfamily);

            }

            public bool selectPerio_tx_Comment(int fkvdfamily)
            {

                return dataworkerObj.selectPerio_tx_Comment(fkvdfamily);

            }

            public bool selectOther_Comment(int fkvdfamily)
            {

                return dataworkerObj.selectOther_Comment(fkvdfamily);

            }


            public bool selectGraphy_needed(int fkvdfamily)
            {

                return dataworkerObj.selectGraphy_needed(fkvdfamily);

            }

            public bool selectRestorative(int fkvdfamily)
            {

                return dataworkerObj.selectRestorative(fkvdfamily);

            }

            public bool selectRCT(int fkvdfamily)
            {

                return dataworkerObj.selectRCT(fkvdfamily);

            }

            public bool selectDentalSurgery(int fkvdfamily)
            {

                return dataworkerObj.selectDentalSurgery(fkvdfamily);

            }
            public bool selectPerioTx(int fkvdfamily)
            {

                return dataworkerObj.selectPerioTx(fkvdfamily);

            }

            public bool selectOther(int fkvdfamily)
            {

                return dataworkerObj.selectOther(fkvdfamily);

            }


            public bool screen_historical(int fkvdfamily, int code)
            {
                return dataworkerObj.screen_historical(fkvdfamily, code);
            }

            public int delete_screen1(Int32 pk_dent_Screen1)
            {
                return dataworkerObj.generaldelete("dent_screen1 ", "pk_dent_Screen1=" + pk_dent_Screen1.ToString());
            }

            public string Ins_serach_screen1(int fkvdfamily, string date)
            {
                return dataworkerObj.generalselect_count("dent_screen2 ", " pk_dent_Screen2 as F1 ", "fk_vdfamily= " + fkvdfamily + " and FirstScreenDate=" + "''" + date + "''" + "and deleted=0");
            }

            public bool xml_5(string fdate, string tdate, int zarib,int kind)
            {
                return dataworkerObj.Xml_5(fdate, tdate, zarib,kind);
            }

            public bool reporting37(string fdate, string tdate, int zarib)
            {
                return dataworkerObj.reporting37(fdate, tdate, zarib);
            }

            public bool xml_5_view(string fdate, string tdate, int zarib,int kind)
            {
                return dataworkerObj.Xml_5(fdate, tdate, zarib,kind);
            }

            public Int64 insertDentscreen2(
                                        int fk_doctor,
                                        string FirstScreenDate,
                                        Int64 fk_vst,
                                        int fk_vdfamily,
                                        string DentalSurgeryComment,
                                        string RestorativeTxComment,
                                        string RCTComment,
                                        string PaComment,
                                        string OtherRadioGraphyComment,
                                        string OCCLComment,
                                        string EmergenyTxComment,
                                        string OrupPathoComment,
                                        string OtherFindingComment,
                                        string cheifcomplain,
                                        string CurettageComment,
                                        string PerioSxComment,
                                        string ClComment,
                                        string TPCom,
                                        string RctCom,
                                        string NGCom,
                                        string OtherCom,
                                        string ExtractionComment,
                                        int IllnessHistory,
                                        int Pregnant,
                                        int BMTStatus,
                                        int Outmouth,
                                        int TMJ,
                                        int mucousmouth,
                                        int PeriodentalStatus,
                                        int Prosthodonti,
                                        int Occlusion ,
                                        int needlerning,
                                        int needborosazh,
                                        int needfeloride,
                                        int needjerm,
                                        int needfishorsilant,
                                        int  dentalneed,
                                        int gharbalgari,
                                        byte Doctors_Consult,
                                        string Doctors_Consult_text,
                                        byte Dentist_Consult ,
                                        string Dentist_Consult_text

                                       )
            {
                return dataworkerObj.generalinsert(
                    "dent_screen2",
                    "fk_doctor ,	FirstScreenDate ,fk_vst  ,fk_vdfamily  ,DentalSurgeryComment ,RestorativeTxComment ,RCTComment , PaComment , OtherRadioGraphyComment , OCCLComment , EmergenyTxComment , OrupPathoComment , OtherFindingComment , cheifcomplain , CurettageComment , PerioSxComment , ClComment , TPCom  , RctCom , NGCom , OtherCom , ExtractionComment ,IllnessHistory,Pregnant,BMTStatus, Outmouth ,TMJ,mucousmouth,PeriodentalStatus,Prosthodonti,Occlusion,needlerning,needborosazh,needfeloride,needjerm,needfishorsilant,dentalneed,gharbalgari,Doctors_Consult,Doctors_Consult_text,Dentist_Consult,Dentist_Consult_text",
                      fk_doctor + " , " +
                       "''" + FirstScreenDate + "''" + " , " +
                      fk_vst + " , " +
                      fk_vdfamily + " , " +
                      "''" + DentalSurgeryComment + "''" + " , " +
                      "''" + RestorativeTxComment + "''" + " , " +
                      "''" + RCTComment + "''" + " , " +
                      "''" + PaComment + "''" + " , " +
                      "''" + OtherRadioGraphyComment + "''" + " , " +
                      "''" + OCCLComment + "''" + " , " +
                      "''" + EmergenyTxComment + "''" + " , " +
                      "''" + OrupPathoComment + "''" + " , " +
                      "''" + OtherFindingComment + "''" + " , " +
                      "''" + cheifcomplain + "''" + " , " +
                      "''" + CurettageComment + "''" + " , " +
                      "''" + PerioSxComment + "''" + " , " +
                      "''" + ClComment + "''" + " , " +
                      "''" + TPCom + "''" + " , " +
                      "''" + RctCom + "''" + " , " +
                      "''" + NGCom + "''" + " , " +
                      "''" + OtherCom + "''" + " , " +
                      "''" + ExtractionComment + "''" + " , " +
                            IllnessHistory + " , " +
                            Pregnant + " , " +
                            BMTStatus + " , " +
                            Outmouth + " , " +
                            TMJ + " , " +
                            mucousmouth + " , " +
                            PeriodentalStatus + " , " +
                            Prosthodonti + " , " +
                            Occlusion + " , " +
                            needlerning + " , " +
                            needborosazh + " , " +
                            needfeloride + " , " +
                            needjerm + " , " +
                            needfishorsilant + " , " +
                            dentalneed + " , " +
                            gharbalgari+ " , " +
                            Doctors_Consult + " , " +
                            "''" + Doctors_Consult_text + "''" + " , " +
                            Dentist_Consult + " , " +
                            "''" + Dentist_Consult_text + "''" 


                    );
            }

            public int updateDentscreen2(
                                        Int64 pk_dent_Screen2,
                                        string DentalSurgeryComment,
                                        string RestorativeTxComment,
                                        string RCTComment,
                                        string PaComment,
                                        string OtherRadioGraphyComment,
                                        string OCCLComment,
                                        string EmergenyTxComment,
                                        string OrupPathoComment,
                                        string OtherFindingComment,
                                        string cheifcomplain,
                                        string CurettageComment,
                                        string PerioSxComment,
                                        string ClComment,
                                        string TPCom,
                                        string RctCom,
                                        string NGCom,
                                        string OtherCom,
                                        string ExtractionComment,
                                        int IllnessHistory,
                                        int Pregnant,
                                        int BMTStatus,
                                        int Outmouth,
                                        int TMJ,
                                        int mucousmouth,
                                        int PeriodentalStatus,
                                        int Prosthodonti,
                                        int Occlusion ,
                                        int needlerning,
                                        int needborosazh,
                                        int needfeloride,
                                        int needjerm,
                                        int needfishorsilant,
                                        int  dentalneed,
                                        int gharbalgari,
                                        byte Doctors_Consult,
                                        string Doctors_Consult_text,
                                        byte Dentist_Consult ,
                                        string Dentist_Consult_text
                                    )
            {
                return dataworkerObj.generalupdate(
                    "dent_screen2", 
                     "DentalSurgeryComment= " + "''" + DentalSurgeryComment + "''" + " , " +
                     "RestorativeTxComment= " + "''" + RestorativeTxComment + "''" + " , " +
                      "RCTComment =" + "''" + RCTComment + "''" + " , " +
                      "PaComment =" + "''" + PaComment + "''" + " , " +
                      "OtherRadioGraphyComment =" + "''" + OtherRadioGraphyComment + "''" + " , " +
                      "OCCLComment =" + "''" + OCCLComment + "''" + " , " +
                      "EmergenyTxComment =" + "''" + EmergenyTxComment + "''" + " , " +
                      "OrupPathoComment =" + "''" + OrupPathoComment + "''" + " , " +
                      "OtherFindingComment =" + "''" + OtherFindingComment + "''" + " , " +
                      "cheifcomplain =" + "''" + cheifcomplain + "''" + " , " +
                      "CurettageComment =" + "''" + CurettageComment + "''" + " , " +
                      "PerioSxComment =" + "''" + PerioSxComment + "''" + " , " +
                      "ClComment =" + "''" + ClComment + "''" + " , " +
                      "TPCom =" + "''" + TPCom + "''" + " , " +
                      "RctCom =" + "''" + RctCom + "''" + " , " +
                      "NGCom =" + "''" + NGCom + "''" + " , " +
                      "OtherCom =" + "''" + OtherCom + "''" + " , " +
                      "ExtractionComment =" + "''" + ExtractionComment + "''" + " , " +
                      "IllnessHistory =" + IllnessHistory + " , " +
                      "Pregnant =" + Pregnant + " , " +
                      "BMTStatus =" + BMTStatus + " , " +
                      "Outmouth =" + Outmouth + " , " +
                      "TMJ =" + TMJ + " , " +
                      "mucousmouth =" + mucousmouth + " , " +
                      "PeriodentalStatus =" + PeriodentalStatus + " , " +
                      "Prosthodonti =" + Prosthodonti + " , " +
                      "Occlusion =" + Occlusion + " , " +
                      "needlerning =" + needlerning + " , " +
                      "needborosazh =" + needborosazh + " , " +
                      "needfeloride =" + needfeloride + " , " +
                      "needjerm =" + needjerm + " , " +
                      "needfishorsilant =" + needfishorsilant + " , " +
                      "dentalneed =" + dentalneed + " , " +
                       "gharbalgari =" + gharbalgari + " , " +
                       "Doctors_Consult =" + Doctors_Consult + " , " +
                       "Doctors_Consult_text =" + "''" + Doctors_Consult_text + "''" + " , " +
                       "Dentist_Consult =" + Dentist_Consult + " , " +
                       "Dentist_Consult_text =" + "''" + Dentist_Consult_text + "''" ,
                       "pk_dent_Screen2= " + pk_dent_Screen2
                     );
            }


            public Int64 insertDentscreen1(
                                 Int64 fk_dent_Screen2,
                                 int toothid,
                                 int fk_dent_neededService,
                                 string SpecificationDate,
                                 string PAComment,
                                 string Tcomment,
                                 string RctComment2,
                                 string DentalSurgeryComment,
                                 string ExtractionComment,
                                 string CLComment,
                                 string OtherFindingComment

                                )
            {
                return dataworkerObj.generalinsert(
                    "dent_screen1",
                    "fk_dent_Screen2 ,	toothid ,fk_dent_neededService  ,SpecificationDate  ,PAComment ,Tcomment ,RctComment2 , DentalSurgeryComment , ExtractionComment , CLComment , OtherFindingComment ",
                      fk_dent_Screen2 + " , " +
                      toothid + " , " +
                      fk_dent_neededService + " , " +
                       "''" + SpecificationDate + "''" + " , " +
                      "''" + PAComment + "''" + " , " +
                      "''" + Tcomment + "''" + " , " +
                      "''" + RctComment2 + "''" + " , " +
                      "''" + DentalSurgeryComment + "''" + " , " +
                      "''" + ExtractionComment + "''" + " , " +
                      "''" + CLComment + "''" + " , " +
                      "''" + OtherFindingComment + "''"

                    );
            }


            public Int64 insertIllnessHistoryPaient(Int64 fk_dent_Screen2, Int64 IllnessHistory)
            {
                return dataworkerObj.generalinsert("IllnessHistoryPaient", "fk_dent_Screen2,IllnessHistory", fk_dent_Screen2 + " , " + IllnessHistory);
            }

            public Int64 insertillnesshistory(string IllnessHistorydesc)
            {
                return dataworkerObj.generalinsert("IllnessHistory", "IllnessHistorydesc", "''"+IllnessHistorydesc+"''");
            }

        }       
          
       

        public class refering
        {

            public string conectionstring;
            public System.Data.SqlClient.SqlDataReader datasource;
            public System.Data.SqlClient.SqlCommand referingclientdataset;
            protected DataAcessClass.DataAcessClass.dataworker dataworkerObj;

            public int GroupIdentityNumber;
            public int FileIdentityNumber;

            public refering()
            {
                dataworkerObj = new DataAcessClass.DataAcessClass.dataworker();
                referingclientdataset = dataworkerObj.clientdataset;
                conectionstring = dataworkerObj.conectionstring;
            }


            public bool Dbconnset(bool connected)
            {
                if (connected)
                    dataworkerObj.openconn();
                else
                    dataworkerObj.closeconn();
                return connected;
            }

            public bool search_persontbl_refer(int Fkvdfamily)
            {
                return dataworkerObj.search_persontbl_refer(Fkvdfamily);
            }


            public Int64 insert_refer(
                
                        string Fkvdfamily,
                        string  PersNo,
                        string Refredate,
                        string RefreTime,
                        string ReferUser
                
                )
            {
                return dataworkerObj.generalinsert("refer", "Fkvdfamily,PersNo,Refredate,RefreTime,ReferUser",
                      Fkvdfamily + " , " +
                      PersNo + " , " +
                      "''" + Refredate + "''" + " , " +
                      "''" + RefreTime + "''" + " , " +
                      ReferUser
                    );
            }



            public Int64 insert_Refer_status(

            string Refer_code,
            string Refer_status_code           
    )
            {
                return dataworkerObj.generalinsert("Refer_status", "Refer_code,Refer_status_code",
                      Refer_code + " , " +
                      Refer_status_code
                    );
            }


            //****************referout
            public Int64 insert_referout(

                   string Idperson,
	               int  Persno ,
	               int Fkvdfamily ,
                   string Personalcode ,
	               string ReferOutDate ,
                   string ReferOutTime ,
	               int Doctorscode ,
	               string Descriptions ,
	               byte ReferCauseCode ,
	               string ReferCauseDesc ,
                   int ReferOutUser  ,
                   string Ipadress   

            )
            {
                return dataworkerObj.generalinsert("ReferOut", "Idperson,Persno,Fkvdfamily,Personalcode,ReferOutDate,ReferOutTime,Doctorscode,Descriptions,ReferCauseCode,ReferCauseDesc,ReferOutUser,ipadress",
                      
                     "''" +Idperson+ "'' ," +
	                Persno+ " , " +
	                Fkvdfamily+ " , " +
                    "''"  + Personalcode + "'' ," +
	                "''" + ReferOutDate+ "'' ," +
                    "''" + ReferOutTime+ "'' ," +
	                Doctorscode+ " , " +
	                 "''" +Descriptions+ "'' ," +
	                ReferCauseCode+ " , " +
	                 "''" +ReferCauseDesc + "'' ," +
                    ReferOutUser+ " , " +
                    "''" +Ipadress+ "'' " 
                    );
            }

            public bool Referoutsearch(string fromdate, string todate, int persno , byte kind)
             {
                return dataworkerObj.Referoutsearch(fromdate,todate,persno,kind);
             }

            public int deletereferout(int referoutcode)
            {
                return dataworkerObj.generalupdate("ReferOut", "deleted=1", "ReferOutCode =" + referoutcode);
            }
        }


        public class familydentist
        {

            public string conectionstring;
            public System.Data.SqlClient.SqlDataReader datasource;
            public System.Data.SqlClient.SqlCommand familydentistclientdataset;
            protected DataAcessClass.DataAcessClass.dataworker dataworkerObj;


            public familydentist()
            {
                dataworkerObj = new DataAcessClass.DataAcessClass.dataworker();
                familydentistclientdataset = dataworkerObj.clientdataset;
                conectionstring = dataworkerObj.conectionstring;
            }


            public bool Dbconnset(bool connected)
            {
                if (connected)
                    dataworkerObj.openconn();
                else
                    dataworkerObj.closeconn();
                return connected;
            }

           
            public Int64 insert_familydentist(string Dentist_code, byte status,int usercode,string ipadress,string insertdate,string inserttime)
            {
                return dataworkerObj.generalinsert(
                    "Family_Dentist",
                    "Dentist_code, status, usercode, ipadress, insertdate, inserttime" , 
                    Dentist_code+ " , " +
                    status + " , " +
                    usercode+ " , " +
                 "''" + ipadress + "''" + " , " +  
                 "''" + insertdate + "''" + " , " +  
                 "''" + inserttime + "''" 
                 );                                    
                 
            }

            public int changestatus(string dentistcode,byte status)
            {
                return dataworkerObj.generalupdate("Family_Dentist", "status= " + status, "Dentist_code= "+ dentistcode);
            }

            public string search_familydentistperson(int fkvdfamily)
            {
                return dataworkerObj.generalselect_count("Family_Dentist_Person", "top 1 Dentistcode as F1", "fk_vdfamily = " + fkvdfamily + "order by Family_Dentist_Personcode desc");
            }

              public string checkFkvdfamilyRecipe_familydentist(int fkvdfamily,string dentistcode, string datet, int code, out string tdate)
            {
                return dataworkerObj.checkFkvdfamilyRecipe_familydentist(fkvdfamily,dentistcode,datet,code,out tdate);
            }

              public Int64 insert_Family_Dentist_Person(int fk_vdfamily,int Persno,string Dentistcode,string fromdate,string todate,int usercode,string ipadress,string insertdate,string inserttime)
              {
                  return dataworkerObj.generalinsert(
                      "Family_Dentist_Person",
                      "fk_vdfamily, Persno, Dentistcode, fromdate, todate, usercode, ipadress, insertdate, inserttime",
                      fk_vdfamily + " , " +
                      Persno + " , " +
                      Dentistcode + " , " +
                      "''" + fromdate + "''" + " , " +
                      "''" + todate + "''" + " , " +  
                      usercode+ " , " +
                      "''" + ipadress + "''" + " , " +  
                      "''" + insertdate + "''" + " , " +  
                      "''" + inserttime + "''"                                               
                      );
              }

              public int update_Family_Dentist_Person_todate(int fk_vdfamily,string todate)
              {
                  return dataworkerObj.generalupdate("Family_Dentist_Person", "todate =" +"''"+ todate+"''", "fk_vdfamily =" +fk_vdfamily +  "and todate= " + "''-''");
              }

            public bool Family_Dentist_Person_view(int fk_vdfamily)
            {
                return dataworkerObj.generalJoinselect("Family_Dentist_Person","Family_Dentist_Personcode,  Family_Dentist_Person.fromdate, Family_Dentist_Person.todate, PersianTitle + ''  '' + Fname + ''  '' + Lname AS drname","fk_vdfamily =" +fk_vdfamily + "order by Family_Dentist_Personcode desc" ,"TblUsers ON Family_Dentist_Person.Dentistcode = TblUsers.UserCode");
            }

        }


        public class Screentemp
        {

            public string conectionstring;
            public System.Data.SqlClient.SqlDataReader datasource;
            public System.Data.SqlClient.SqlCommand Screenclientdataset;
            protected DataAcessClass.DataAcessClass.dataworker dataworkerObj;

           

            public Screentemp()
            {
                dataworkerObj = new DataAcessClass.DataAcessClass.dataworker();
                Screenclientdataset = dataworkerObj.clientdataset;
                conectionstring = dataworkerObj.conectionstring;
            }


            public bool Dbconnset(bool connected)
            {
                if (connected)
                    dataworkerObj.openconn();
                else
                    dataworkerObj.closeconn();
                return connected;
            }


             public bool selectdentscreen2(Int64 Dentscreen2)
            {
                return dataworkerObj.generalselect("dent_screen2", "*", "pk_dent_Screen2 = " + Dentscreen2);
            }

             public bool selectillnesshistory(Int64 Dentscreen2, int llnesshistory)
             {
                 return dataworkerObj.generalselect("IllnessHistoryPaient", "*", "fk_dent_Screen2 = " + Dentscreen2 + " and IllnessHistory = " + llnesshistory);
             }

            public int delete_dentscreen2(Int32 pk_dentscreen)
            {
                return dataworkerObj.generalupdate("dent_screen2","deleted=1","pk_dent_Screen2 = " + pk_dentscreen);
            }

            public string retunnspecialitykindcode(Int32 doctorscode)
            {
                return dataworkerObj.generalselect_count("TblUsers", "specialityKindCode as F1","usercode= " + doctorscode);
            }

            public Int64 insertIllnessHistoryPaient(Int64 fk_dent_Screen2, Int64 IllnessHistory)
            {
                return dataworkerObj.generalinsert("IllnessHistoryPaient", "fk_dent_Screen2,IllnessHistory", fk_dent_Screen2 + " , " + IllnessHistory);
            }

  
        }       
    }

}

                         
