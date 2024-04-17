﻿using AutoMapper;
using churchApp.Models;
using churchApp.Models.Tables;
using churchApp.Repo;
using churchApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace churchApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly HomeRepo repo;
        private readonly JwtTokenGeneration jwt;

        private readonly AccountRepo accountRepo;

        public HomeController(HomeRepo repo, JwtTokenGeneration jwt, AccountRepo accountRepo)
        {
            this.repo = repo;
            this.jwt = jwt;

            this.accountRepo = accountRepo;
        }
        [Authorize]
        [Route("[controller]/getPrayer")]
        [HttpGet]
        public async Task<IActionResult> getPrayerRequest()
        {
            try
            {
                var data = await repo.GetAllPrayers();
                if (data == null)
                {
                    return NotFound("No request");
                }
                return Ok(data);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }
        [Authorize]
        [Route("[controller]/postPrayer")]
        [HttpPost]
        public async Task<IActionResult> postPrayerRequest([FromBody] PrayerModel model)
        {
            try
            {
                if (ModelState.IsValid)

                {
                    var toke = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
                    var emailId = jwt.getEmailIdFromToken(toke);
                    var userExist = await accountRepo.UserExist(emailId);
                    model.userId = userExist.Id;
                    var repoRespone = await repo.PostPrayerRequest(model);
                    if (repoRespone)
                    {

                        return Ok(new { message = "Prayer request sent successfully " });
                    }
                }
                return BadRequest(ModelState);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }

        }
        [Authorize]
        [Route("[controller]/getAllMeetings")]
        [HttpGet]
        public async Task<IActionResult> getMeetings()
        {
            try
            {
                var data = await repo.GetAllMeetings();

                return Ok(new { data = data });


            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        
        [Route("[controller]/postMeeting")]
        [HttpPost]
        public async Task<IActionResult>postMeetings([FromBody]MeetingModel model)
        {
            try {
            var res=await repo.PostMeeting(model);
                if(res)
                    return Ok(new {respone="Meeting created successfully"});
                else
                    return BadRequest(new {response="Something went wrong"});
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
