using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace Project.Api.Configurations
{
    public class CustomRoutingConvetion : IControllerModelConvention
    {
        public void Apply(ControllerModel controller)
        {
            var words = System.Text.RegularExpressions.Regex.Split(
                controller.ControllerName,
                @"(?<!^)(?=[A-Z])"
            );

            var route = "api/" + string.Join("-", words).ToLower() + "s";

            controller.Selectors[0].AttributeRouteModel = new AttributeRouteModel(
                new RouteAttribute(route)
            );
        }
    }
}
