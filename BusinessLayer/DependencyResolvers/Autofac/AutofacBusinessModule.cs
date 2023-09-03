using Autofac;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AboutManager>().As<IAboutService>().SingleInstance();
            builder.RegisterType<AnnouncementManager>().As<IAnnouncementService>().SingleInstance();
            builder.RegisterType<ContactManager>().As<IContactService>().SingleInstance();
            builder.RegisterType<ExperienceManager>().As<IExperienceService>().SingleInstance();
            //builder.RegisterType<FeatureManager>().As<IFeatureService>().SingleInstance();
            builder.RegisterType<MessageManager>().As<IMessageService>().SingleInstance();
            builder.RegisterType<PortfolioManager>().As<IPortfolioService>().SingleInstance();
            builder.RegisterType<ServiceManager>().As<IServiceService>().SingleInstance();
            builder.RegisterType<SkillManager>().As<ISkillService>().SingleInstance();
            builder.RegisterType<SocialMediaManager>().As<ISocialMediaService>().SingleInstance();
            builder.RegisterType<TestimonialManager>().As<ITestimonialService>().SingleInstance();
            builder.RegisterType<ToDoListManager>().As<IToDoListService>().SingleInstance();
            builder.RegisterType<WriterManager>().As<IWriterMessageService>().SingleInstance();
            builder.RegisterType<WriterMessageManager>().As<IWriterMessageService>().SingleInstance();
        }
    }
}
