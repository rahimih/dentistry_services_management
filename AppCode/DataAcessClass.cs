using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Xml;

namespace DataAcessClass
{
  public  class DataAcessClass
    {
     public static string aa;
     public static byte bb;
  
     public class dataworker
     {
         public string procedureName;
         public string procedureParameters;
         public int OperatorPersonalCode;
         public string OperatorDate;
         public string OperatorTime;
         public string conectionstring;
         public string result;
         public SqlCommand clientdataset;
         public SqlDataReader datareader;
         protected SqlConnection databaseconnection;
         public Int64 identitynumber;
         public DateTime miladidate;
         public string shamsidate;
         public DateTime sdate;
            public string str1;

         public dataworker()
         {


       //------------------

             XmlTextReader XmlRdr = new XmlTextReader("Dentist.xml");

            while(!XmlRdr.EOF)

            {
    
              if (XmlRdr.MoveToContent() == XmlNodeType.Element)

                switch (XmlRdr.Name)

            {

                                
                    case "ipadress":

                        str1 = XmlRdr.ReadElementString();

                        break;

                  default:

                        XmlRdr.Read();

                        break;

            }

              else

                  XmlRdr.Read();

            }
         
            XmlRdr.Close();
       
         
             //-------------------------
       
             conectionstring = ("user id=DentistryUser;data source=\""+str1+"\";persist security in" +
                                   "fo=True;initial catalog=Dentistry;password=\"dentistrynothing\";connection timeout=120");
             databaseconnection = new SqlConnection(conectionstring);
             clientdataset = new SqlCommand("", databaseconnection);
         }

         public bool openconn()
         {
             databaseconnection.Open();
             return true;
         }

         public bool closeconn()
         {
             databaseconnection.Close();
             return true;
         }



         public DateTime shamsitomiladi(string shamsidate)
         {
             procedureName = "sp_shamsitomiladi ";
             procedureParameters =
               "@shamsidate = '" + shamsidate + "'";

             databaseconnection.Open();
             clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
             datareader = clientdataset.ExecuteReader();
             datareader.Read();
             miladidate = Convert.ToDateTime(datareader["miladidate"].ToString());
             databaseconnection.Close();
             return miladidate;
         }

         public string miladitoshamsi(DateTime miladidate)
         {
             procedureName = "sp_miladitoshamsi ";
             procedureParameters =
               "@miladidate = '" + miladidate + "'";

             databaseconnection.Open();
             clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
             datareader = clientdataset.ExecuteReader();
             datareader.Read();
             shamsidate = (datareader["shamsidate"].ToString());
             databaseconnection.Close();
             return shamsidate;
         }

         public DateTime getdate()
         {
             procedureName = "getdate ";
            
             databaseconnection.Open();
             clientdataset.CommandText = "Exec " + procedureName ;
             datareader = clientdataset.ExecuteReader();
             datareader.Read();
             sdate = Convert.ToDateTime(datareader["sdate"].ToString());
             databaseconnection.Close();
             return sdate;

         }
         public string quotedstr(string sstr)
         {
             return "'" + sstr + "'";
         }

         public Int64 generalinsert(string tablename,
                                  string fields,
                                  string values
                                  )
         {

             procedureName = "GeneralInsert ";
             procedureParameters =
               "@Tables = '" + tablename + "' , " +
               "@Fields = '" + fields + "' , " +
               "@Values = '" + values + "' ";
             databaseconnection.Open();
             clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
             datareader = clientdataset.ExecuteReader();
             datareader.Read();
             identitynumber = Convert.ToInt64(datareader["identitynumber"].ToString());
             databaseconnection.Close();
             return identitynumber;

         }

         public int generalupdate(string tablename,
                                  string values,
                                  string conditions
                                  )
         {
             procedureName = " GeneralUpdate ";
             procedureParameters =
               "@Tables = '" + tablename + "' , " +
               "@Values = '" + values + "' , " +
               "@Conditions = '" + conditions + "' ";
             databaseconnection.Open();
             clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
             clientdataset.ExecuteNonQuery();
             databaseconnection.Close();
             return 1;
             //		Result := DataWorkerClientDataSet.FieldByName("IdentityNumber").AsInteger;
         }

         public int generaldelete(string tablename,
                                  string conditions
                                  )
         {
             procedureName = " GeneralDelete ";
             procedureParameters =

               "@Tables = '" + tablename + "' , " +
               "@Conditions = '" + conditions + "' ";
             databaseconnection.Open();
             clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
             clientdataset.ExecuteNonQuery();
             databaseconnection.Close();
             return 1;
             //		Result := DataWorkerClientDataSet.FieldByName("IdentityNumber").AsInteger;
         }

         public bool generalselect(string tablename,
                                  string fields,
                                  string conditions
                                  )
         {
             procedureName = " GeneralSelect ";
             procedureParameters =

               "@Tables = '" + tablename + "' , " +
               "@Conditions = '" + conditions + "' , " +
               "@Fields = '" + fields + "' , " +
               "@Code = 0";
           
             databaseconnection.Open();
             clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
             if (clientdataset.ExecuteReader().HasRows == true)
             {

                 
                 databaseconnection.Close();
                 return true;
             }
             else
             {

                 databaseconnection.Close();
                 return false;
             }
             
         }

         public bool generalJoinselect(string tablename,
                                string fields,
                                string conditions,
                                string tablename2
                                )
         {
             procedureName = " GeneraljoinSelect ";
             procedureParameters =

               "@Tables = '" + tablename + "' , " +
               "@Conditions = '" + conditions + "' , " +
               "@Fields = '" + fields + "' , " +
               "@JoinTables  = '" + tablename2 + "' ";
             databaseconnection.Open();
             clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
             if (clientdataset.ExecuteReader().HasRows == true)
             {
                 databaseconnection.Close();
                 return true;
             }
             else
             {
                 databaseconnection.Close();
                 return false;
             }
         }

         public string generalselect_count(string tablename,
                              string fields,
                              string conditions
                              )
         {

             procedureName = " GeneralSelect ";
             procedureParameters =

               "@Tables = '" + tablename + "' , " +
               "@Conditions = '" + conditions + "' , " +
               "@Fields = '" + fields + "' , " +
               "@Code = 0";
             databaseconnection.Open();
             clientdataset.CommandText = "Exec " + procedureName + procedureParameters;

             datareader = clientdataset.ExecuteReader();
             if (datareader.HasRows==false)
                result="-1";
             else
           {
               datareader.Read();
               result = datareader["F1"].ToString();
           }
             databaseconnection.Close();
             return result;
             /*
                  if (clientdataset.ExecuteReader().HasRows == true)
                  {
                
                      return true;
                      databaseconnection.Close();
                
                  }
                  else
                  {
                      databaseconnection.Close();
                      return false;
                  } */
         }



         public bool generalselect_CTE(string tablename,
                                  string aliasFields,
                                  string firstConditions,
                                  string Fields,
                                  string MainFields,
                                  string joinTables,
                                  string lastConditions
                                  )
         {
             procedureName = " GeneralSelect ";
             procedureParameters =
               "@Tables = '" + tablename + "' , " +
               "@AliasFields = '" + aliasFields + "' , " +
               "@Conditions = '" + firstConditions + "' , " +
               "@MainFields = '" + MainFields + "' , " +
               "@Fields = '" + Fields + "' , " +
               "@JoinTables = '" + joinTables + "' , " +
               "@Conditions_2 = '" + lastConditions + "' , " +
               "@Code = 1";

             databaseconnection.Close();
             databaseconnection.Open();
             clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
             if (clientdataset.ExecuteReader().HasRows == true)
             {
                 databaseconnection.Close();
              
                 return true;
             }
             else
             {
                 databaseconnection.Close();
                 return false;
             }
             
         }

         public bool checkduplicatevacations(int doctorscode,
                               string fromdate,
                               string todate
                               )
         {
             procedureName = " checkduplicatevacations ";
             procedureParameters =

                doctorscode + " , " +
               " '" + fromdate + "' , " +
               " '" + todate + "' ";

             databaseconnection.Open();
             clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
             if (clientdataset.ExecuteReader().HasRows == true)
             {
                 databaseconnection.Close();
                 return true;
             }
             else
             {
                 databaseconnection.Close();
                 return false;
             }
         }
         public bool checkdeleteplanvist(int planvisitcode)
         {
             procedureName = "CheckDeleteplanvist ";
             procedureParameters = planvisitcode.ToString();

             databaseconnection.Open();
             clientdataset.CommandText = "exec " + procedureName + procedureParameters;
             if (clientdataset.ExecuteReader().HasRows == true)
             {
                 databaseconnection.Close();
                 return true;
             }
             else
             {
                 databaseconnection.Close();
                 return false;
             }


         }

         public bool vacationinplanvisit(int doctorscode, string visitdate)
         {
             procedureName = "vacationinplanvisit ";
             procedureParameters =
                 doctorscode + " , " +
                   " '" + visitdate + "' ";

           
             databaseconnection.Open();
             clientdataset.CommandText = "exec " + procedureName + procedureParameters;
             if (clientdataset.ExecuteReader().HasRows == true)
             {

                 databaseconnection.Close();
                 return true;
             }
             else
             {
                databaseconnection.Close();
                 return false;
             }
            
         }

         public bool Duplicateinplanvisit(int doctorscode, string visitdate, TimeSpan fromtime, TimeSpan totime,int kind)
         {

             procedureName = "Duplicateinplanvisit ";
             procedureParameters =
                 doctorscode + " , " +
                   " '" + visitdate + "' , " +
                   " '" + fromtime + "' , " +
                    " '" + totime + "' , " +
                   " '" + kind + "'  "

                    ;


            // databaseconnection.Close();
             databaseconnection.Open();
             clientdataset.CommandText = "exec " + procedureName + procedureParameters;
             if (clientdataset.ExecuteReader().HasRows == true)
             {
                 databaseconnection.Close();
                 return true;
             }
             else
             {
                 databaseconnection.Close();
                 return false;
             }
             
         }


         public bool Duplicateineditplanvisit(int doctorscode, string visitdate, TimeSpan fromtime, TimeSpan totime,int kind,int planvisitcode)
         {

             procedureName = "Duplicateineditplanvisit ";
             procedureParameters =
                 doctorscode + " , " +
                   " '" + visitdate + "' , " +
                   " '" + fromtime + "' , " +
                    " '" + totime + "' , " +
                    " '" + kind + "' , " +
                    planvisitcode;


             // databaseconnection.Close();
             databaseconnection.Open();
             clientdataset.CommandText = "exec " + procedureName + procedureParameters;
             if (clientdataset.ExecuteReader().HasRows == true)
             {
                 databaseconnection.Close();
                 return true;
             }
             else
             {
                 databaseconnection.Close();
                 return false;
             }

         }

         public bool serviceshistory(int fkvdfamily, string visitdate)
         {
             procedureName = "ServicesHistory ";
             procedureParameters =
                 fkvdfamily + " , " +
                   " '" + visitdate + "'  ";
             databaseconnection.Open();
             clientdataset.CommandText = "exec " + procedureName + procedureParameters;
             if (clientdataset.ExecuteReader().HasRows == true)
             {
                 databaseconnection.Close();
                 return true;
             }
             else
             {
                 databaseconnection.Close();
                 return false;
             }

         }

         public bool servicesRadiohistory(int fkvdfamily, string visitdate)
         {
             procedureName = "ServicesRadioHistory ";
             procedureParameters =
                 fkvdfamily + " , " +
                   " '" + visitdate + "'  ";
             databaseconnection.Open();
             clientdataset.CommandText = "exec " + procedureName + procedureParameters;
             if (clientdataset.ExecuteReader().HasRows == true)
             {
                 databaseconnection.Close();
                 return true;
             }
             else
             {
                 databaseconnection.Close();
                 return false;
             }

         }


         public bool InternalServicesHistory(int fkvdfamily, string turndate1,string turndate2)
         {
             procedureName = "InternalServicesHistory ";
             procedureParameters =
                 fkvdfamily + " , " +
                   " '" + turndate1 + "' , " +
                   " '" + turndate2 + "'  ";
             databaseconnection.Open();
             clientdataset.CommandText = "exec " + procedureName + procedureParameters;
             if (clientdataset.ExecuteReader().HasRows == true)
             {
                 databaseconnection.Close();
                 return true;
             }
             else
             {
                 databaseconnection.Close();
                 return false;
             }

         }

         public bool InternalServicesHistoryfull(int fkvdfamily, string turndate1, string turndate2)
         {
             procedureName = "InternalServicesHistoryfull ";
             procedureParameters =
                 fkvdfamily + " , " +
                   " '" + turndate1 + "' , " +
                   " '" + turndate2 + "'  ";
             databaseconnection.Open();
             clientdataset.CommandText = "exec " + procedureName + procedureParameters;
             if (clientdataset.ExecuteReader().HasRows == true)
             {
                 databaseconnection.Close();
                 return true;
             }
             else
             {
                 databaseconnection.Close();
                 return false;
             }

         }

         public bool Internal_detailServicesHistory(int recipeid)
         {
             procedureName = "Internal_detailServicesHistory ";
             procedureParameters =
                " @recipeid= " + recipeid ;

             databaseconnection.Close();
             databaseconnection.Open();
             clientdataset.CommandText = "exec " + procedureName + procedureParameters;
             if (clientdataset.ExecuteReader().HasRows == true)
             {
                 databaseconnection.Close();
                 return true;
             }
             else
             {
                 databaseconnection.Close();
                 return false;
             }

         }

         public bool selectCostConfirm(int fkvdfamily, string visitdate)
         {
             procedureName = "selectCostConfirm ";
             procedureParameters =
                 fkvdfamily + " , " +
                   " '" + visitdate + "'  ";
             databaseconnection.Open();
             clientdataset.CommandText = "exec " + procedureName + procedureParameters;
             if (clientdataset.ExecuteReader().HasRows == true)
             {
                 databaseconnection.Close();
                 return true;
             }
             else
             {
                 databaseconnection.Close();
                 return false;
             }

         }

         public bool selectCostConfirm_head(string startdate, string enddate)
         {
             procedureName = "selectCostConfirm_head ";
             procedureParameters =
             "@fromdate = '" + startdate + "'  , " +
             "@enddate = '" + enddate + "'  ";
             databaseconnection.Open();
             clientdataset.CommandText = "exec " + procedureName + procedureParameters;
             if (clientdataset.ExecuteReader().HasRows == true)
             {
                 databaseconnection.Close();
                 return true;
             }
             else
             {
                 databaseconnection.Close();
                 return false;
             }
         }


         public bool selectCostConfirm_detail(int costconfirmHeadCode)
         {
             procedureName = " selectCostConfirm_detail ";
             procedureParameters =
             "@costconfirmHeadCode = " + costconfirmHeadCode;

             databaseconnection.Close();
             databaseconnection.Open();
             clientdataset.CommandText = "exec " + procedureName + procedureParameters;
             if (clientdataset.ExecuteReader().HasRows == true)
             {
                 databaseconnection.Close();
                 return true;
             }
             else
             {
                 databaseconnection.Close();
                 return false;
             }
         }

         public bool introduction_Headselect(string startdate, string enddate)
         {
             procedureName = " Introduction_headSelect ";
             procedureParameters =
               "@satrtdate = '" + startdate + "'  , " +
               "@enddate = '" + enddate + "'  ";

             databaseconnection.Open();
             clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
             if (clientdataset.ExecuteReader().HasRows == true)
             {
                 databaseconnection.Close();
                 return true;
             }
             else
             {
                 databaseconnection.Close();
                 return false;
             }
         }

         public bool introduction_Detailselect(int introductionheadcode)
         {
             procedureName = " selectIntroduction_detail ";
             procedureParameters =
             "@IntroductionHeadCode = " + introductionheadcode;

             databaseconnection.Close();
             databaseconnection.Open();
             clientdataset.CommandText = "exec " + procedureName + procedureParameters;
             if (clientdataset.ExecuteReader().HasRows == true)
             {
                 databaseconnection.Close();
                 return true;
             }
             else
             {
                 databaseconnection.Close();
                 return false;
             }
         }

         public bool introductionselect_persno(int persno)
         {
             procedureName = " IntroductionSelect_pesno ";
             procedureParameters =
               "@persno = " + persno;

             databaseconnection.Open();
             clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
             if (clientdataset.ExecuteReader().HasRows == true)
             {
                 databaseconnection.Close();
                 return true;
             }
             else
             {
                 databaseconnection.Close();
                 return false;
             }
         }


         public bool report1(string startdate, string enddate)
         {
             procedureName = " report1 ";
             procedureParameters =
               "@startdate = '" + startdate + "'  , " +
               "@enddate = '" + enddate + "'  ";

             databaseconnection.Open();
             clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
             if (clientdataset.ExecuteReader().HasRows == true)
             {
                 databaseconnection.Close();
                 return true;
             }
             else
             {
                 databaseconnection.Close();
                 return false;
             }
         }

         public bool report2(string startdate, string enddate)
         {
             procedureName = " report2 ";
             procedureParameters =
               "@startdate = '" + startdate + "'  , " +
               "@enddate = '" + enddate + "'  ";

             databaseconnection.Open();
             clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
             if (clientdataset.ExecuteReader().HasRows == true)
             {
                 databaseconnection.Close();
                 return true;
             }
             else
             {
                 databaseconnection.Close();
                 return false;
             }
         }

         public bool introductionprint(Int64 introductioncode)
         {
             procedureName = " Introductionprint ";
             procedureParameters =
               "@introductioncode = " + introductioncode;


             databaseconnection.Open();
             clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
             if (clientdataset.ExecuteReader().HasRows == true)
             {
                 databaseconnection.Close();
                 return true;
             }
             else
             {
                 databaseconnection.Close();
                 return false;
             }
         }


         public bool Introductioncommentprint(Int64 introductioncode)
         {
             procedureName = " Introductioncommentprint ";
             procedureParameters =
               "@introductioncode = " + introductioncode;


             databaseconnection.Open();
             clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
             if (clientdataset.ExecuteReader().HasRows == true)
             {
                 databaseconnection.Close();
                 return true;
             }
             else
             {
                 databaseconnection.Close();
                 return false;
             }
         }


         public bool selectplanvisit(string fromdate, byte shiftcode,byte kind)
         {
             procedureName = " selectPlanvisit ";
             procedureParameters =
             "@visitdate = '" + fromdate + "'  , " +
             "@Shiftcode = " + shiftcode + "  , " +
             "@kind = " + kind;

             
             databaseconnection.Open();
             clientdataset.CommandText = "exec " + procedureName + procedureParameters;
             if (clientdataset.ExecuteReader().HasRows == true)
             {
                 databaseconnection.Close();
                 return true;
             }
             else
             {
                 databaseconnection.Close();
                 return false;
             }
         }


         public string selectRecipeError(int fkvdfamily)
         {


             procedureName = "selectRecipeError ";
             procedureParameters =
                  "@Fkvdfamily = " + fkvdfamily;

             databaseconnection.Open();
             clientdataset.CommandText = "exec " + procedureName + procedureParameters;

             datareader = clientdataset.ExecuteReader();
             datareader.Read();
             if (datareader.HasRows == true)
             {
                 aa = " کاربر " + datareader["RecipeUser"].ToString() + "---------" + "  تاریخ" + datareader["insertdate"].ToString() + "\n" + "** " + datareader["Error"].ToString() + " **";

                 databaseconnection.Close();
             }
             else
             {
                 aa = "@@";
                 databaseconnection.Close();
             }

             return aa;

         }


         public string checkFkvdfamilyRecipe(int fkvdfamily, int personalcode,string datet, int code, out string tdate, out string doctorsname)
         {


             procedureName = "checkFkvdfamilyRecipe ";
             procedureParameters =
                  "@Fkvdfamily = " + fkvdfamily + " , " +
                  "@Personelcode = " + personalcode + " , " +
                  "@code = " + code + " , " +
                  "@turndate = '" + datet + "'  ";

             databaseconnection.Open();
             clientdataset.CommandText = "exec " + procedureName + procedureParameters;

             datareader = clientdataset.ExecuteReader();
             datareader.Read();
             if (datareader.HasRows == true)
             {
                 if (code == 0)
                     //aa = " جهت بیمار انتخابی  در تاریخ " + datareader["Turndate"].ToString() + " با دکتر " + datareader["Doctorsname"].ToString() + " نوبت صادر گردیده است";
                     aa = "آخرین نوبت اخذ شده بیمار انتخابی در تاریخ " + datareader["Turndate"].ToString() + " با دکتر " + datareader["Doctorsname"].ToString() + " می باشد";
                 else if (code == 1)
                     //aa = " جهت خانواده بیمار انتخابی  در تاریخ " + datareader["Turndate"].ToString() + " با دکتر " + datareader["Doctorsname"].ToString() + " نوبت صادر گردیده است";
                     aa = "آخرین نوبت اخذ شده توسط خانواده بیمار انتخابی در تاریخ " + datareader["Turndate"].ToString() + " با دکتر " + datareader["Doctorsname"].ToString() + " می باشد";

                 tdate = datareader["Turndate"].ToString();
                 doctorsname = datareader["Doctorsname"].ToString();
                 databaseconnection.Close();
             }
             else
             {
                 aa = "@@";
                 tdate = "-";
                 doctorsname = "-";
                 databaseconnection.Close();
             }

             return aa;

         }

         public byte selectcountRecipe(int Planvisit_code)
         {

             procedureName = "selectcountRecipe ";
             procedureParameters =
                  "@Planvisit_code = " + Planvisit_code;

             databaseconnection.Open();
             clientdataset.CommandText = "exec " + procedureName + procedureParameters;
             datareader = clientdataset.ExecuteReader();
             datareader.Read();

             bb = byte.Parse(datareader["tedad"].ToString());

             databaseconnection.Close();
             return bb;

         }


         public bool selectTurnno(int Planvisit_code)
         {

             procedureName = "selectTurnno ";
             procedureParameters =
                  "@Planvisit_code = " + Planvisit_code;

             databaseconnection.Open();
             clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
             if (clientdataset.ExecuteReader().HasRows == true)
             {
                 databaseconnection.Close();
                 return true;
             }
             else
             {
                 databaseconnection.Close();
                 return false;
             }

         }

         public bool CheckDuplicateTurnno(int Planvisit_code, byte turnno)
         {

             procedureName = "CheckDuplicateTurnno ";
             procedureParameters =
                  "@Planvisit_code = " + Planvisit_code + " , " +
                  "@Turnno = " + turnno;

             databaseconnection.Open();
             clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
             if (clientdataset.ExecuteReader().HasRows == true)
             {
                 databaseconnection.Close();
                 return true;
             }
             else
             {
                 databaseconnection.Close();
                 return false;
             }

         }

         public bool selectPaientList(int doctorscode, string turndate, byte statuscode,byte kind)
         {

             procedureName = "selectPaientList ";
             procedureParameters =
                  "@DoctorsCode = " + doctorscode + " , " +
                   "@Turndate = '" + turndate + "'  , " +
                  "@turnstatus = " + statuscode + "  , " +
                  "@kind = " + kind;

             databaseconnection.Close();
             databaseconnection.Open();
             clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
             if (clientdataset.ExecuteReader().HasRows == true)
             {
                 databaseconnection.Close();
                 return true;
             }
             else
             {
                 databaseconnection.Close();
                 return false;
             }

         }


         public bool selectpersontbl(int persno)
         {
             procedureName = " SelectPersonTbl ";
             procedureParameters =
               "@persno = " + persno;


             databaseconnection.Open();
             clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
             if (clientdataset.ExecuteReader().HasRows == true)
             {
                 databaseconnection.Close();
                 return true;
             }
             else
             {
                 databaseconnection.Close();
                 return false;
             }
         }

         public bool selectpersontblpkvdfamily(int pkvdfamily)
         {

             procedureName = " SelectPersonTblvdfamily ";
             procedureParameters =
               "@pkvdfamily = " + pkvdfamily;


             databaseconnection.Open();
             clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
             if (clientdataset.ExecuteReader().HasRows == true)
             {
                 databaseconnection.Close();
                 return true;
             }
             else
             {
                 databaseconnection.Close();
                 return false;
             }
         }


         public bool medicalrestselect(string startdate, string enddate)
         {
             procedureName = " medicalrestselect ";
             procedureParameters =
               "@satrtdate = '" + startdate + "'  , " +
               "@enddate = '" + enddate + "'  ";

             databaseconnection.Open();
             clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
             if (clientdataset.ExecuteReader().HasRows == true)
             {
                 databaseconnection.Close();
                 return true;
             }
             else
             {
                 databaseconnection.Close();
                 return false;
             }
         }

         public bool medicalrestselect_persno(int persno)
         {
             procedureName = " medicalrestselect_persno ";
             procedureParameters =
               "@persno = " + persno;

             databaseconnection.Open();
             clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
             if (clientdataset.ExecuteReader().HasRows == true)
             {
                 databaseconnection.Close();
                 return true;
             }
             else
             {
                 databaseconnection.Close();
                 return false;
             }
         }


         public bool Consultselect(string startdate, string enddate)
         {
             procedureName = " Consultselect ";
             procedureParameters =
               "@satrtdate = '" + startdate + "'  , " +
               "@enddate = '" + enddate + "'  ";

             
             databaseconnection.Open();
             clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
             if (clientdataset.ExecuteReader().HasRows == true)
             {
                 databaseconnection.Close();
                 return true;
             }
             else
             {
                 databaseconnection.Close();
                 return false;
             }
         }

         public bool Consultselect_persno(int persno)
         {
             procedureName = " Consultselect_persno ";
             procedureParameters =
               "@persno = " + persno;

             databaseconnection.Open();
             clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
             if (clientdataset.ExecuteReader().HasRows == true)
             {
                 databaseconnection.Close();
                 return true;
             }
             else
             {
                 databaseconnection.Close();
                 return false;
             }
         }





         public bool DoctorsCountPaient(string startdate, string enddate)
         {
             procedureName = " DoctorsCountPaient ";
             procedureParameters =
               "@FTurndate = '" + startdate + "'  , " +
               "@ETurndate = '" + enddate + "'  ";


             databaseconnection.Open();
             clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
             if (clientdataset.ExecuteReader().HasRows == true)
             {
                 databaseconnection.Close();
                 return true;
             }
             else
             {
                 databaseconnection.Close();
                 return false;
             }
         }


          public bool selectChiefcomplain(int fkvdfamily)
         {
             procedureName = " selectChiefcomplain ";
             procedureParameters =
               "@fkvdfamily = " + fkvdfamily;

             databaseconnection.Open();
             clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
             if (clientdataset.ExecuteReader().HasRows == true)
             {
                 databaseconnection.Close();
                 return true;
             }
             else
             {
                 databaseconnection.Close();
                 return false;
             }
             
         }
         public bool selectGraphy_comment(int fkvdfamily)
         {
             procedureName = " selectGraphy_comment ";
             procedureParameters =
               "@fkvdfamily = " + fkvdfamily;

             databaseconnection.Open();
             clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
             if (clientdataset.ExecuteReader().HasRows == true)
             {
                 databaseconnection.Close();
                 return true;
             }
             else
             {
                 databaseconnection.Close();
                 return false;
             }
         }
         public bool selectRestorativeTx_Comment(int fkvdfamily)
         {
             procedureName = " selectRestorativeTx_Comment ";
             procedureParameters =
               "@fkvdfamily = " + fkvdfamily;

             databaseconnection.Open();
             clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
             if (clientdataset.ExecuteReader().HasRows == true)
             {
                 databaseconnection.Close();
                 return true;
             }
             else
             {
                 databaseconnection.Close();
                 return false;
             }
         }
         public bool selectRCT_Comment(int fkvdfamily)
         {
             procedureName = " selectRCT_Comment ";
             procedureParameters =
               "@fkvdfamily = " + fkvdfamily;

             databaseconnection.Open();
             clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
             if (clientdataset.ExecuteReader().HasRows == true)
             {
                 databaseconnection.Close();
                 return true;
             }
             else
             {
                 databaseconnection.Close();
                 return false;
             }
         }
          public bool selectExt_Sx_Comment(int fkvdfamily)
         {
             procedureName = " selectExt_Sx_Comment ";
             procedureParameters =
               "@fkvdfamily = " + fkvdfamily;

             databaseconnection.Open();
             clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
             if (clientdataset.ExecuteReader().HasRows == true)
             {
                 databaseconnection.Close();
                 return true;
             }
             else
             {
                 databaseconnection.Close();
                 return false;
             }
         }
           public bool selectPerio_tx_Comment(int fkvdfamily)
         {
             procedureName = " selectPerio_tx_Comment ";
             procedureParameters =
               "@fkvdfamily = " + fkvdfamily;

             databaseconnection.Open();
             clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
             if (clientdataset.ExecuteReader().HasRows == true)
             {
                 databaseconnection.Close();
                 return true;
             }
             else
             {
                 databaseconnection.Close();
                 return false;
             }
         }
           public bool selectOther_Comment(int fkvdfamily)
         {
             procedureName = " selectOther_Comment ";
             procedureParameters =
               "@fkvdfamily = " + fkvdfamily;

             databaseconnection.Open();
             clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
             if (clientdataset.ExecuteReader().HasRows == true)
             {
                 databaseconnection.Close();
                 return true;
             }
             else
             {
                 databaseconnection.Close();
                 return false;
             }
         }


           public bool selectGraphy_needed(int fkvdfamily)
         {
             procedureName = " selectGraphy_needed ";
             procedureParameters =
               "@fkvdfamily = " + fkvdfamily;

             databaseconnection.Open();
             clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
             if (clientdataset.ExecuteReader().HasRows == true)
             {
                 databaseconnection.Close();
                 return true;
             }
             else
             {
                 databaseconnection.Close();
                 return false;
             }
         }

           public bool selectRestorative(int fkvdfamily)
           {
               procedureName = " selectRestorative ";
               procedureParameters =
                 "@fkvdfamily = " + fkvdfamily;

               databaseconnection.Open();
               clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
               if (clientdataset.ExecuteReader().HasRows == true)
               {
                   databaseconnection.Close();
                   return true;
               }
               else
               {
                   databaseconnection.Close();
                   return false;
               }
           }

           public bool selectRCT(int fkvdfamily)
           {
               procedureName = " selectRCT ";
               procedureParameters =
                 "@fkvdfamily = " + fkvdfamily;

               databaseconnection.Open();
               clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
               if (clientdataset.ExecuteReader().HasRows == true)
               {
                   databaseconnection.Close();
                   return true;
               }
               else
               {
                   databaseconnection.Close();
                   return false;
               }
           }

           public bool selectDentalSurgery(int fkvdfamily)
           {
               procedureName = " selectDentalSurgery ";
               procedureParameters =
                 "@fkvdfamily = " + fkvdfamily;

               databaseconnection.Open();
               clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
               if (clientdataset.ExecuteReader().HasRows == true)
               {
                   databaseconnection.Close();
                   return true;
               }
               else
               {
                   databaseconnection.Close();
                   return false;
               }
           }

           public bool selectPerioTx(int fkvdfamily)
           {
               procedureName = " selectPerioTx ";
               procedureParameters =
                 "@fkvdfamily = " + fkvdfamily;

               databaseconnection.Open();
               clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
               if (clientdataset.ExecuteReader().HasRows == true)
               {
                   databaseconnection.Close();
                   return true;
               }
               else
               {
                   databaseconnection.Close();
                   return false;
               }
           }

           public bool selectOther(int fkvdfamily)
           {
               procedureName = " selectOther ";
               procedureParameters =
                 "@fkvdfamily = " + fkvdfamily;

               databaseconnection.Open();
               clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
               if (clientdataset.ExecuteReader().HasRows == true)
               {
                   databaseconnection.Close();
                   return true;
               }
               else
               {
                   databaseconnection.Close();
                   return false;
               }
           }


           public bool screen_historical(int fkvdfamily,int code)
           {
               procedureName = " screen_historical ";
               procedureParameters =
                 "@fkvdfamily = " + fkvdfamily + "  , " +
                 "@TypeScreen_code = " + code;
     
               databaseconnection.Open();
               clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
               if (clientdataset.ExecuteReader().HasRows == true)
               {
                   databaseconnection.Close();
                   return true;
               }
               else
               {
                   databaseconnection.Close();
                   return false;
               }
           }



           public bool Xml_5(string fdate,string tdate,int zarib,int kind)
           {
               procedureName = " xml_5 ";
               procedureParameters = "@fromdate = '" + fdate + "' , "
                                   + "@todate = '" + tdate + "' , " 
                                   +"@zarib = " + zarib + " , " 
                                   +"@kind = " + kind;

               databaseconnection.Open();
               clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
               if (clientdataset.ExecuteReader().HasRows == true)
               {
                   databaseconnection.Close();
                   return true;
               }
               else
               {
                   databaseconnection.Close();
                   return false;
               }
           }

           public bool Xml_5_view(string fdate, string tdate, int zarib,int kind)
           {
               procedureName = " xml_5 ";
               procedureParameters = "@fromdate = '" + fdate + "' , "
                                   + "@todate = '" + tdate + "' , "
                                   + "@zarib = " + zarib + " , "
                                   + "@kind = " + kind;

               databaseconnection.Open();
               clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
               if (clientdataset.ExecuteReader().HasRows == true)
               {
                   databaseconnection.Close();
                   return true;
               }
               else
               {
                   databaseconnection.Close();
                   return false;
               }
           }



           public bool search_persontbl(string persno)
           {
               procedureName = " search_persontbl ";
               procedureParameters =
                 "@persno = " + persno;

               databaseconnection.Open();
               clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
               if (clientdataset.ExecuteReader().HasRows == true)
               {
                   databaseconnection.Close();
                   return true;
               }
               else
               {
                   databaseconnection.Close();
                   return false;
               }
           }


           public bool search_persontbl_refer(int Fkvdfamily)
           {
               procedureName = " search_persontbl_refer ";
               procedureParameters =
                 "@Fkvdfamily = " + Fkvdfamily;

               databaseconnection.Open();
               clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
               if (clientdataset.ExecuteReader().HasRows == true)
               {
                   databaseconnection.Close();
                   return true;
               }
               else
               {
                   databaseconnection.Close();
                   return false;
               }
           }


           public bool Referoutsearch(string fromdate, string todate, int persno , byte kind)
           {
               procedureName = " Referoutsearch ";
               procedureParameters =
               "@firstdate = '" + fromdate + "'  , " +
               "@todate = '" + todate + "'  , " +
               "@persno = " + persno + "  , " +
               "@kind = " + kind;


               databaseconnection.Open();
               clientdataset.CommandText = "exec " + procedureName + procedureParameters;
               if (clientdataset.ExecuteReader().HasRows == true)
               {
                   databaseconnection.Close();
                   return true;
               }
               else
               {
                   databaseconnection.Close();
                   return false;
               }
           }


           public string checkFkvdfamilyRecipe_familydentist(int fkvdfamily,string dentistcode, string datet, int code, out string tdate)
           {
               procedureName = "checkFkvdfamilyRecipe_familydentist ";
               procedureParameters =
                    "@Fkvdfamily = " + fkvdfamily + " , " +
                    "@dentistcode = " + dentistcode + " , " +
                    "@code = " + code + " , " +
                    "@turndate = '" + datet + "'  ";

               databaseconnection.Open();
               clientdataset.CommandText = "exec " + procedureName + procedureParameters;

               datareader = clientdataset.ExecuteReader();
               datareader.Read();
               if (datareader.HasRows == true)
               {
                   aa = "@";
                   tdate = datareader["Turndate"].ToString();                   
                   databaseconnection.Close();
               }
               else
               {
                   aa = "@@";
                   tdate = "-";
                   databaseconnection.Close();
               }

               return aa;

           }



           public bool reporting37(string fdate, string tdate, int zarib)
           {
               procedureName = " reporting37 ";
               procedureParameters = "@fromdate = '" + fdate + "' , "
                                   + "@todate = '" + tdate + "' , "
                                   + "@zarib = " + zarib;

               databaseconnection.Open();
               clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
               if (clientdataset.ExecuteReader().HasRows == true)
               {
                   databaseconnection.Close();
                   return true;
               }
               else
               {
                   databaseconnection.Close();
                   return false;
               }
           }



         public bool Services_Group_view_h()
           {
               procedureName = " Services_Group_view_h ";
              
               databaseconnection.Open();
               clientdataset.CommandText = "Exec " + procedureName ;
               if (clientdataset.ExecuteReader().HasRows == true)
               {
                   databaseconnection.Close();
                   return true;
               }
               else
               {
                   databaseconnection.Close();
                   return false;
               }

           }

         public bool Services_Group_view_d(int groupcode)
         {
             procedureName = " Services_Group_view_d ";
             procedureParameters = "@groupcode = " + groupcode;

             databaseconnection.Close();
             databaseconnection.Open();
             clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
             if (clientdataset.ExecuteReader().HasRows == true)
             {
                 databaseconnection.Close();
                 return true;
             }
             else
             {
                 databaseconnection.Close();
                 return false;
             }

         }


         public bool log_view(string fromdate, string todate, string kind)
         {
             procedureName = " log_view ";
             procedureParameters = "@fromdate = '" + fromdate + "' , "
                                 + "@todate = '" + todate + "' , "
                                 + "@kind = " + kind;

             databaseconnection.Open();
             clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
             databaseconnection.Close();
             return true;
            
         }

         
     
     }

    
    }

}
