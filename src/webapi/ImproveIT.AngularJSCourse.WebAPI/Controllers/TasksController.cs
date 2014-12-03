using ImproveIT.AngularJSCourse.Domain;
using ImproveIT.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ImproveIT.AngularJSCourse.WebAPI.Controllers
{

    /// <summary>
    /// Controller for tasks
    /// </summary>
    public class TasksController : ApiController
    {

        internal IDataContext DataContext { get; set; }

        //GET api/task
        public IList<object> Get()
        {
            var user01 = new { id = 1, name = "Oscar", lastname = "Sanchez" };
            var user02 = new { id = 2, name = "Beatriz", lastname = "Torres" };
            var user03 = new { id = 3, name = "Alonso", lastname = "Roque" };

            var task01 = new { id = 1, code = "TSK01", description = "Implementar la notificación de la creación de una borrador de reporte de falla", status = "Planeada", user = user01 };
            var task02 = new { id = 2, code = "TSK02", description = "Agregar la unidad de medida del número de parte", status = "En proceso", user = user02 };
            var task03 = new { id = 3, code = "TSK03", description = "Implementar Envio de Cotización por parte del proveedor", status = "Completada", user = user03 };
            return new List<object>() { task01, task02, task03 }.ToArray();
        }

        //Post api/task
        public void Post(object task)
        {
            dynamic dTask = task;
            var description = dTask.Description;
            var userId = dTask.UserId;
            Task newTask = new Task();
            newTask.Description = description;
            newTask.User.Id = userId;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dataContext"></param>
        public TasksController(IDataContext dataContext)
        {
            this.DataContext = dataContext;
        }
    }
}
