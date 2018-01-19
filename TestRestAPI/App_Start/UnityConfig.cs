using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using TestRestAPI.Repositories;
using TestRestAPI.Repositories.Interfaces;
using Unity;
using Unity.WebApi;

namespace TestRestAPI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            container.RegisterType<IPostsService, PostsService>();
            container.RegisterType<ICommentsService, CommentService>();
            container.RegisterType<IAuthorsService, AuthorsService>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}