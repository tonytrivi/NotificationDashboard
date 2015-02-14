using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using NotificationDashboardPrototype.Data;

namespace NotificationDashboardPrototype.Controllers
{
    public class StatusNotificationsController : ApiController
    {
        private NotificationModelContext db = new NotificationModelContext();
        private INotificationDashboardRepository _repo;



        public StatusNotificationsController(INotificationDashboardRepository repo) {
            _repo = repo;
        
        }

        // GET: api/StatusNotifications
        public IQueryable<StatusNotification> GetStatusNotifications()
        {
            //return _repo.GetStatusNotifications().Include("Server").AsQueryable();
            return _repo.GetStatusNotifications();
        }

        // GET: api/StatusNotifications/5
        [ResponseType(typeof(StatusNotification))]
        public IHttpActionResult GetStatusNotification(int id)
        {
            StatusNotification statusNotification = _repo.GetStatusNotification(id); 
            if (statusNotification == null)
            {
                return NotFound();
            }

            return Ok(statusNotification);
        }

        // PUT: api/StatusNotifications/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStatusNotification(int id, StatusNotification statusNotification)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != statusNotification.StatusNotificationId)
            {
                return BadRequest();
            }

            db.Entry(statusNotification).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatusNotificationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/StatusNotifications
        [ResponseType(typeof(StatusNotification))]
        public IHttpActionResult PostStatusNotification([FromBody]StatusNotification statusNotification)
        {

            // we want to associate this notification with a server
            var server = _repo.GetServer(statusNotification.Server.Name);
            statusNotification.ServerId = server.ServerId;
            statusNotification.Server = null;

            if (_repo.AddStatusNotification(statusNotification) && _repo.Save()) {
                return CreatedAtRoute("DefaultApi", new { id = statusNotification.StatusNotificationId }, statusNotification);

            }

            // we are going to let them know that the Add didn't work
            return BadRequest(ModelState);
          

        }

        // DELETE: api/StatusNotifications/5
        [ResponseType(typeof(StatusNotification))]
        public IHttpActionResult DeleteStatusNotification(int id)
        {
            StatusNotification statusNotification = db.StatusNotifications.Find(id);
            if (statusNotification == null)
            {
                return NotFound();
            }

            db.StatusNotifications.Remove(statusNotification);
            db.SaveChanges();

            return Ok(statusNotification);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StatusNotificationExists(int id)
        {
            return db.StatusNotifications.Count(e => e.StatusNotificationId == id) > 0;
        }
    }
}