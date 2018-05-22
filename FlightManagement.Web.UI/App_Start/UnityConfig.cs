using AutoMapper;
using FlightManagement.Domain.Contexte;
using FlightManagement.Domain.Domain;
using FlightManagement.IRepository.Airport;
using FlightManagement.IRepository.Flight;
using FlightManagement.IRepository.Plane;
using FlightManagement.IService.Airport;
using FlightManagement.IService.Flight;
using FlightManagement.IService.Plane;
using FlightManagement.Repository.Airport;
using FlightManagement.Repository.Flight;
using FlightManagement.Repository.Plane;
using FlightManagement.Service.Airport;
using FlightManagement.Service.Flight;
using FlightManagement.Service.Plane;
using FlightManagement.Web.UI.Models;
using System.Data.Entity;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace FlightManagement.Web.UI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container =  BuildUnityContainer();
            //BuildMapper();
            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            container.RegisterType<DbContext, FlightsDbContext>();

            #region Repository
            container.RegisterType<IAirportRepository,AirportRepository> ();
            container.RegisterType <IPlaneRepository,PlaneRepository> ();
            container.RegisterType <IFlightRepository,FlightRepository> ();
            #endregion

            #region Service
            container.RegisterType <IAirportService, AirportService> ();
            container.RegisterType<IPlaneService, PlaneService>();
            container.RegisterType<IFlightService, FlightService>();
            #endregion


            return container; 
        }

        private static void BuildMapper()
        {
            //Mapper.Map<Flight, FlightModel>();
        }

    }
}