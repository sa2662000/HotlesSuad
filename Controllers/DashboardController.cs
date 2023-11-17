using Hotles.Data;
using Hotles.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using MailKit;
using MailKit.Net.Smtp;
using MimeKit;
using Org.BouncyCastle.Crypto.Macs;

namespace Hotels.Controllers
{
	public class DashboardController : Controller
	{
		private readonly ApplicationDbContext _context;

		public DashboardController(ApplicationDbContext context)
		{
			_context = context;

		}
		//zewfoudkhukwkoem
		public async Task<String> SendEmail()
		{
			var messge = new MimeMessage();
			messge.From.Add(new MailboxAddress("Test Messag", "suadd0044@gmail.com"));
			messge.To.Add(MailboxAddress.Parse("shhs20210@gmail.com"));
			messge.Subject="Test EMail Form My Project in ASP.NET COER MVC";
			messge.Body = new TextPart("Plain")
			{
				Text = "Welcome IN My App"
			};
			using(var client=new SmtpClient())
			{
				try
				{
					client.Connect("smtp.gamail.com", 587);
					client.Authenticate("suadd0044@gmail.com", "zewfoudkhukwkoem");
					await client.SendAsync(messge);
					client.Disconnect(true);
				}
				catch(Exception e)
				{
                  return e.Message.ToString();
				}
			}
			return "OK";
		}
		public IActionResult Delete(int id)
		{
			var hotelDel = _context.hotles.SingleOrDefault(x => x.Id == id);
			if (hotelDel != null)
			{
				_context.hotles.Remove(hotelDel);
				_context.SaveChanges();
				TempData["Del"] = "Ok";
			}

			return RedirectToAction("Index");
		}
		public IActionResult DeleteRooms(int id)
		{
			var roomsdell = _context.rooms.SingleOrDefault(v => v.Id==id);
			if(roomsdell != null)
			{
				_context.rooms.Remove(roomsdell);
				_context.SaveChanges();
				TempData["Del"] = "OK";
			}
			return RedirectToAction("Rooms");
		
		}
		public IActionResult DeleteRoomsDetails(int id)
		{
			var RoomslDel = _context.roomDetails.SingleOrDefault(x => x.Id == id);
			if (RoomslDel != null)
			{
				_context.roomDetails.Remove(RoomslDel);
				_context.SaveChanges();
				TempData["Del"] = "Ok";
			}

			return RedirectToAction("RoomDetails");

		}

		public IActionResult CreateNewRecord(Hotle hotle)

        {
            _context.hotles.Add(hotle);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult Update(Hotle hotle)
        {
			_context.hotles.Update(hotle);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

		public IActionResult EditRooms(int ID)
        {
            var roomedit =_context.roomDetails.SingleOrDefault(x => x.Id == ID);
            return View(roomedit);
        }
		public IActionResult UpdateRoomsD(RoomDetails roomDetails)
		{
			_context.roomDetails.Update(roomDetails);
			_context.SaveChanges();
			return RedirectToAction("RoomDetails");
		}

		public IActionResult Edit(int ID)
		{
			var hoteledit = _context.hotles.SingleOrDefault(x => x.Id == ID);
			return View(hoteledit);
		}
		public IActionResult UpdateRooms(Rooms rooms)
        {
            _context.rooms.Update(rooms);
            _context.SaveChanges();
            return RedirectToAction("Rooms");
        }
        public IActionResult RoomsEdit(int ID)
		{
			var roomsedit = _context.rooms.SingleOrDefault(x => x.Id == ID);
			return View(roomsedit);
		}
		public IActionResult CreateNewRooms(Rooms rooms)
        {
            _context.rooms.Add(rooms);
            _context.SaveChanges(); 
			return RedirectToAction("Rooms");
		}
		public IActionResult CreateNewRoomDetails(RoomDetails Roomsd)
		{
			_context.roomDetails.Add(Roomsd);
			_context.SaveChanges();
			return RedirectToAction("RoomDetails");
		}
		[HttpPost]
        public IActionResult Index(String City)
        {
            var findhotel = _context.hotles.Where(x => x.City.Contains(City));
            return View(findhotel);
        }
		public IActionResult RoomDetails()
		{
			ViewBag.currentuser = HttpContext.Session.GetString("UserName");
			var hotel = _context.hotles.ToList();
			ViewBag.hotel = hotel;

			var roomss = _context.rooms.ToList();
			ViewBag.roomss = roomss;

			var rooms = _context.roomDetails.ToList();
			return View(rooms);
			//var hotel = _context.hotles.ToList();
			//ViewBag.hotel = hotel;
			//return View();


		}
		public IActionResult Rooms()
		{
			//ViewBag.currentuser = Request.Cookies["UserName"];
			ViewBag.currentuser =HttpContext.Session.GetString("UserName");
			var hotel=_context.hotles.ToList();
            ViewBag.hotel = hotel;
            var rooms=_context.rooms.ToList();
			return View(rooms);
		}
        [Authorize]
		public IActionResult Index()
        {
            var currentuser = HttpContext.User.Identity.Name;
            ViewBag.currentuser = currentuser;
			//CookieOptions option = new CookieOptions();
			//option.Expires = DateTime.Now.AddMinutes(20);
			//Response.Cookies.Append("UserName", currentuser,option);
			HttpContext.Session.SetString("UserName",currentuser);
			var hotel = _context.hotles.ToList();
            return View(hotel);
        }
      






    }
}