using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAcessClass;
using BussinessClass;

namespace  DLibraryUtils
{
   public  class DLUtils
    {
       


        public BussinessClass.BussinessClass.userchecking usercheckingobj;
        public BussinessClass.BussinessClass.EventsLog EventsLogobj;
        public BussinessClass.BussinessClass.Clinics clinicsobj;
        public BussinessClass.BussinessClass.planvisit planvisitobj;
        public BussinessClass.BussinessClass.Doctorsworktime doctorsworktimeobj;
        public BussinessClass.BussinessClass.ContractoutCenter ContractoutCenterobj;
        public BussinessClass.BussinessClass.vacations vacationsobj;
        public BussinessClass.BussinessClass.tariffs tariffsobj;
        public BussinessClass.BussinessClass.Services Servicesobj;
        public BussinessClass.BussinessClass.CostConfirm costconfirmobj;
        public BussinessClass.BussinessClass.persontbl persontblobj;
        public BussinessClass.BussinessClass.introductions introductionsobj;
        public BussinessClass.BussinessClass.Recipe recipeobj;
        public BussinessClass.BussinessClass.medicalrest medicalrestobj;
        public BussinessClass.BussinessClass.consult consultobj;
        public BussinessClass.BussinessClass.Screentemp Screentempobj;
        public BussinessClass.BussinessClass.Screen screenobj;
        public BussinessClass.BussinessClass.refering referingobj;
        public BussinessClass.BussinessClass.familydentist familydentistobj;




        public DLUtils()
        {
            usercheckingobj = new BussinessClass.BussinessClass.userchecking();
            EventsLogobj = new BussinessClass.BussinessClass.EventsLog();
            clinicsobj = new BussinessClass.BussinessClass.Clinics();
            planvisitobj = new BussinessClass.BussinessClass.planvisit();
            doctorsworktimeobj = new BussinessClass.BussinessClass.Doctorsworktime();
            ContractoutCenterobj = new BussinessClass.BussinessClass.ContractoutCenter();
            vacationsobj = new BussinessClass.BussinessClass.vacations();
            tariffsobj = new BussinessClass.BussinessClass.tariffs();
            Servicesobj = new BussinessClass.BussinessClass.Services();
            costconfirmobj = new BussinessClass.BussinessClass.CostConfirm();
            persontblobj = new BussinessClass.BussinessClass.persontbl();
            introductionsobj = new BussinessClass.BussinessClass.introductions();
            recipeobj = new BussinessClass.BussinessClass.Recipe();
            medicalrestobj = new BussinessClass.BussinessClass.medicalrest();
            consultobj = new BussinessClass.BussinessClass.consult();
            screenobj = new BussinessClass.BussinessClass.Screen();
            Screentempobj = new BussinessClass.BussinessClass.Screentemp();
            referingobj = new BussinessClass.BussinessClass.refering();
            familydentistobj = new BussinessClass.BussinessClass.familydentist();

        }
    }
}
