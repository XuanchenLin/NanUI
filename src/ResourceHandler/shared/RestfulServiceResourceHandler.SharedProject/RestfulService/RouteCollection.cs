using NetDimension.NanUI.ResourceHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetDimension.NanUI.RestfulService
{
    internal class RouteCollection
    {
        readonly List<Route> Routes = new List<Route>();

        public Route GetRoute(Method method, string path)
        {
            return Routes.FirstOrDefault(x => x.Path.Equals(path, StringComparison.CurrentCultureIgnoreCase) && (x.Method == method || x.Method == Method.None));
        }

        public bool IsRouteExists(Route route)
        {
            return IsRouteExists(route.Method, route.Path);
        }

        public bool IsRouteExists(Method method, string path)
        {
            lock (Routes)
            {
                return Routes.Exists(x => x.Method == method && x.Path.Equals(path, StringComparison.CurrentCultureIgnoreCase));
            }
        }

        public void Remove(Route route)
        {
            lock (Routes)
            {
                var entity = Routes.SingleOrDefault(x => x.Method == route.Method && x.Path.Equals(route.Path, StringComparison.CurrentCultureIgnoreCase));

                if (entity != null)
                {
                    Routes.Remove(entity);
                }

            }
        }

        public void Remove(Method method, string path)
        {
            lock (Routes)
            {
                var entity = Routes.SingleOrDefault(x => x.Method == method && x.Path.Equals(path, StringComparison.CurrentCultureIgnoreCase));

                if (entity != null)
                {
                    Routes.Remove(entity);
                }
            }
        }

        public void RemoveRange(IEnumerable<Route> routes)
        {
            foreach (var route in routes)
            {
                Remove(route);
            }
        }

        public void Add(Route route)
        {
            lock (Routes)
            {
                var entity = Routes.SingleOrDefault(x => x.Method == route.Method && x.Path.Equals(route.Path, StringComparison.CurrentCultureIgnoreCase));

                if (entity != null)
                {
                    Routes.Remove(entity);
                }

                Routes.Add(route);
            }
        }



        public void AddRange(IEnumerable<Route> routes)
        {
            lock (Routes)
            {
                foreach (var route in routes)
                {
                    var entity = Routes.SingleOrDefault(x => x.Method == route.Method && x.Path.Equals(route.Path, StringComparison.CurrentCultureIgnoreCase));

                    if (entity != null)
                    {
                        Routes.Remove(entity);
                    }

                    Routes.Add(route);

                }
            }
        }
    }
}
