using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace MusicApi.Controllers {
    public class GroupController : Controller {
        List<Group> allGroups {get; set;}
        public GroupController() {
            allGroups = JsonToFile<Group>.ReadJson();
        }
		// (Optional) Add an extra boolean parameter to the group routes called displayArtists that will include members for all Group JSON responses
		[Route("groups/name/{groupname}/{displayArtists}")]
		[HttpGet]
		public JsonResult DisplayArtists(string groupname, bool displayArtists)
		{
			string g = groupname;
			allGroups = JsonToFile<Group>.ReadJson();
			List<Group> grp = allGroups.Where(group =>
			{
				if (group.GroupName.Replace(" ", "").ToLower() == groupname.ToLower())
				{ return true; }
				return false;
			}).ToList();

			// if (displayArtists)
			// {	
			// 	List<Artist> allArtists = JsonToFile<Artist>.ReadJson();
			// 	var members = allArtists.Join(grp, artId => artId.GroupId, grpId => grpId.Id, 
			// 	(grpId, artId)=>
			// 	{ return artId;});
			// 	return Json(members);
			// }
			return Json(grp);
		}
	}
}