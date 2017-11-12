using StructureMap;
using Actions.Interfaces;
using Actions;
using DAL.Repositories.Interface;
using DAL.Repositories;
using AutoMapper;

namespace Web.Portal
{

    public static class IoC
    {
        public static IContainer Initialize()
        {
            ObjectFactory.Initialize(x =>
                        {
                            x.Scan(scan =>
                                    {
                                        scan.TheCallingAssembly();
                                        scan.WithDefaultConventions();
                                    });
                            //                x.For<IExample>().Use<Example>();

                            //actions
                            x.For<IPersonsAction>().Use<PersonsAction>();

                            //repositories
                            x.For<IPersonsRepository>().Use<PersonsRepository>();

                            //mapper
                            //x.For<IMapper>().Use()
                        });
            return ObjectFactory.Container;
        }
    }
}