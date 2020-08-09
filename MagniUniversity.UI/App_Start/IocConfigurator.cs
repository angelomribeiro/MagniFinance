using Autofac;
using Autofac.Integration.Mvc;
using MagniUniversity.Data.Context;
using MagniUniversity.Data.Repository;
using MagniUniversity.Domain.Repository;
using MagniUniversity.Service.Interface;
using MagniUniversity.Service.Service;
using System.Web.Mvc;

namespace MagniUniversity.UI.App_Start
{
    public static class IocConfigurator
    {
        public static void ConfigureDependencyInjection()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<CourseService>().As<ICourseService>();
            builder.RegisterType<SubjectService>().As<ISubjectService>();
            builder.RegisterType<TeacherService>().As<ITeacherService>();
            builder.RegisterType<StudentService>().As<IStudentService>();
            builder.RegisterType<MagniUniversityContext>().InstancePerRequest();

            builder.RegisterType<CourseRepository>().As<ICourseRepository>();
            builder.RegisterType<SubjectRepository>().As<ISubjectRepository>();
            builder.RegisterType<TeacherRepository>().As<ITeacherRepository>();
            builder.RegisterType<StudentRepository>().As<IStudentRepository>();
            builder.RegisterType<EnrollmentRepository>().As<IEnrollmentRepository>();

            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}