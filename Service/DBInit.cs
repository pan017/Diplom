using Diplom.Model;
using Diplom.Model.Lookups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Service
{
    public static class DBInit
    {
        public static void init()
        {
            ViewModel db = new ViewModel();
            if (!db.Gender.Any())
            {
                db.Gender.Add(new Gender() { Name = "Мужской" });
                db.Gender.Add(new Gender() { Name = "Женский" }); 
            }
            if(!db.FamilyState.Any())
            {
                db.FamilyState.Add(new FamilyState() { Name = "Холост" });
                db.FamilyState.Add(new FamilyState() { Name = "Не замужем" });
                db.FamilyState.Add(new FamilyState() { Name = "Замужем" });
                db.FamilyState.Add(new FamilyState() { Name = "Женат" }); 
            }
            if(!db.Role.Any())
            {
                db.Role.Add(new Role() { Name = "admin" });
                db.Role.Add(new Role() { Name = "user" });  
            }
            if(!db.Education.Any())
            {
                db.Education.Add(new Education() { Name = "Базовое" });
                db.Education.Add(new Education() { Name = "Среднее" });
                db.Education.Add(new Education() { Name = "Средне-специальное" });
                db.Education.Add(new Education() { Name = "Высшее" });
                db.Education.Add(new Education() { Name = "Отсутсвует" });          
            }
            if(!db.CognetiveLoadType.Any())
            {
                db.CognetiveLoadType.Add(new CognetiveLoadType() { Name = "Логический" });
                db.CognetiveLoadType.Add(new CognetiveLoadType() { Name = "Интеллектуальный" });
                db.CognetiveLoadType.Add(new CognetiveLoadType() { Name = "Математичкий" });
            }
            if(!db.TestType.Any())
            {
                db.TestType.Add(new TestType() { Name = "Распределение внимания", TestTypeIndex = 0 });
                db.TestType.Add(new TestType() { Name = "Время реакции", TestTypeIndex = 1 });
            }
            if(!db.TestStage.Any())
            {
                db.TestStage.Add(new TestStage() { Name = "Без когнетивной нагрузки", TestStageIndex = 0 });
                db.TestStage.Add(new TestStage() { Name = "С когнетивной нагрузкой", TestStageIndex = 1 });
                db.TestStage.Add(new TestStage() { Name = "С звуокой нагрузкой", TestStageIndex = 2 });
            }
            db.SaveChanges();
        }
    }
}
