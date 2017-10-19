using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QandA.Methods;
using QandA.Db;
using QandA.Interface;
namespace QandA.Models
{
    public class NinjectModule : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            Bind<QandAEntities>().ToSelf();
            Bind<IAnswerRepository>().To<AnswerRepository>();
            Bind<IQuestionsRepository>().To<QuestionsRepository>();
            Bind<IUserRepository>().To<UserRepository>();
        }
    }
}