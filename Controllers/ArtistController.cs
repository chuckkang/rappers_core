using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace MusicApi.Controllers {

    
    public class ArtistController : Controller {

        private List<Artist> allArtists;
		private List<Artist> lstArtist = JsonToFile<Artist>.ReadJson();
        public ArtistController() {
            allArtists = JsonToFile<Artist>.ReadJson();
        }

        //This method is shown to the user navigating to the default API domain name
        //It just display some basic information on how this API functions
        [Route("")]
        [HttpGet]
        public string Index() {
            //String describing the API functionality
            string instructions = "Welcome to the Music API~~\n========================\n";
            instructions += "    Use the route /artists/ to get artist info.\n";
            instructions += "    End-points:\n";
            instructions += "       *Name/{string}\n";
            instructions += "       *RealName/{string}\n";
            instructions += "       *Hometown/{string}\n";
            instructions += "       *GroupId/{int}\n\n";
            instructions += "    Use the route /groups/ to get group info.\n";
            instructions += "    End-points:\n";
            instructions += "       *Name/{string}\n";
            instructions += "       *GroupId/{int}\n";
            instructions += "       *ListArtists=?(true/false)\n";
            return instructions;
        }

		// Create a route /artists/name/{name} that returns all artists that match the provided name
		[Route("artists/name/{name}")]
		[HttpGet]
		public JsonResult ArtistName(string name)
		{	
			List<Artist> lstArtist = JsonToFile<Artist>.ReadJson();
			List<Artist> getArtist = lstArtist.Where(artist => artist.ArtistName.ToLower() == name.ToLower()).ToList();
			return Json(getArtist);
		}

		//Create a route /artists/realname/{name} that returns all artists who real names match the provided name
		[Route("artists/realname/{name}")]
		[HttpGet]
		public JsonResult RealName(string name)
		{
			List<Artist> lstArtist = JsonToFile<Artist>.ReadJson();
			List<Artist> getArtist = lstArtist.Where(artist => {
				if (artist.RealName.ToLower().Contains(name.ToLower()))
				{
					return true;
				}
				return false;
			}).ToList();
			return Json(getArtist);
		}

		// Create a route /artists/groupid/{id} that returns all artists who have a GroupId that matches id
		[Route("artists/groupid/{id}")]
		[HttpGet]
		public JsonResult GroupById(int id)
		{
			List<Artist> samegroup = lstArtist.Where(artist => artist.GroupId == id).ToList();
			return Json(samegroup);
		}
	}
}