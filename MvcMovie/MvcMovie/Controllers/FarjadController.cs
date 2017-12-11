using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcMovie.Controllers
{
    public class FarjadController : Controller
    {
        //
        // GET: /Farjad/
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET : /Farjad/Welcome
        public string Welcome()
        {
            return "اینم یک صفحه ی دیگه که به صورت استاتیک توسط کنترلر ایجاد شده و در آدرس localhost/Farjad/Welcome قابل دسترس هست. </br> یعنی شما در قسمت کنترلر هر اسمی رو برای تابع انتخاب کنید میشه یه آدرس!";
        }


        // 
        // Get : /Farjad/Par1/
        public string Par1()
        {
            return "ما توی کنترلی که ایجاد کردیم یک تابع درست کردیم به است Farjad که از نوع String یا همون رشته هست. این تابع میفهمه که قراره یه نوشته ای رو به کاربر نشون بده. ولی این رشته یا همون نوشته توی کجا قراره به نمایش در بیاد! MVC بهتون میگه این همون آدرسیه که شما دارید تایپ می کنید. یعنی یه صفحه براتون ایجاد می کنه به است Farjad یا Welcome که اگر آخر آدرس تایپ بشه ، بهتون اون رشته رو نمایش میده! شاید کمی سخت توضیح دادم! آدرس URL شما همون چیزیه که دارید تابع ایجاد می کنید. مثلاً الان میخوام یه صفحه ی دیگه داشته باشم و توش یه سری چیزهای دیگه نوشته شده! مثلاً همین پارارگراف. ";
        }


        // 
        // Get : /Farjad/FarjadV/
        public ActionResult FarjadV()
        {
            return View();
        }

        //
        // Get : /Farjad/PassDCV/
        //public ActionResult PassDCV1(string name, int teedaaad = 1 )
        //{
        //    ViewBag.Message = "انتقال نام و یا نوشته ای برای نمایش" + name;
        //    ViewBag.Teedaad = teedaaad;

        //}

        public ActionResult PassDCV(string name, int numTimes = 1)
        {
            ViewBag.Message = "انتقال نام و یا نوشته ای برای نمایش " + name;
            ViewBag.NumTimes = numTimes;

            return View();
        }


	}
}