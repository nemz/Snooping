﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MardomEvaluationTest.Models;
using MardomEvaluationTest.Infraestructure.ViewModels;
using MardomEvaluationTest.Infraestructure.InputModels;
using MardomEvaluationTest.Filters;
using System.Web.Security;
using System.Security.Policy;
using MardomEvaluationTest.Utilities;

namespace MardomEvaluationTest.Controllers
{
    [InitializeSimpleMembership]
    public class SnoopController : BasicController
    {
        //
        // GET: /Snoop/
        private SnoopingDBEntities _contextDB = new SnoopingDBEntities();

        public ActionResult Index(string username = "")
        {
            var listSnoobs = _contextDB.Snoops.Where(
                r => r.UserProfile.UserName == username).ToList();

            var lstSnoopsView = new List<SnoopViewModel>();
            var snoopView = new SnoopViewModel();


            foreach(var snoop in listSnoobs)
            {
                snoopView = new SnoopViewModel(snoop);
                lstSnoopsView.Add(snoopView);
            }

            return View(lstSnoopsView);
        }

        public ActionResult Profile()
        {
           
            var username = Membership.GetUser().UserName;

            var listSnoobs = _contextDB.Snoops.Where(
                r => r.UserProfile.UserName == username).ToList();

            var followInfo = _contextDB.FollowsCount.FirstOrDefault(
                r => r.UsersInfo.UserProfile.UserName == username);

            var lstSnoopsView = new List<SnoopViewModel>();
            var snoopView = new SnoopViewModel();
            ViewBag.Followers = followInfo.FollowersCount;
            ViewBag.Followed = followInfo.FollowedCount;

            foreach (var snoop in listSnoobs)
            {
                snoopView = new SnoopViewModel(snoop);
                snoopView.Snoop = HashTag.GetHashTag(snoopView.Snoop);
                lstSnoopsView.Add(snoopView);
            }
            

            return View("Index", lstSnoopsView);
        }
        
        public ActionResult AgregarSnoop(SnoopInputModel snoopInputModel)
        {
             var guardar = false;
            int userId = WebMatrix.WebData.WebSecurity.CurrentUserId;

            if (ModelState.IsValid)
            {
                var snoop = new Snoops()
                {
                    Private = snoopInputModel.Private,
                    DateSnoop = DateTime.Now,
                    Snoop = snoopInputModel.Snoop,
                    UserID = userId
                };               

                if (snoopInputModel.Image != null)
                {
                    Guid imageGuid = Guid.NewGuid();

                    snoop = new Snoops()
                    {
                        Private = snoopInputModel.Private,
                        DateSnoop = DateTime.Now,
                        Snoop = snoopInputModel.Snoop,
                        UserID = userId,
                        Images = new Images()
                        {
                            ImageBin = snoopInputModel.Image,
                            ImageGuid = imageGuid
                        },
                        ImageGuid = imageGuid
                    };
                }

                _contextDB.Snoops.Add(snoop);
                guardar = _contextDB.SaveChanges() > 0 ? true : false;
            }

            return Json(new { Result = guardar });
        }


    }
}
