﻿using DevExpress.XtraPrinting.Export;
using Quartz;
using Quartz.Impl;
using ShantiTirttula.Domain.Managers.Managment.Shedules;
using ShantiTirttula.Domain.Models.Managment.Shedules;
using ShantiTirttula.Repository.Managers.Managment.Shedules;
using ShantiTirttula.Repository.Models.Managment.Shedules;

namespace ShantiTirttula.Server.Api.Helpers.Quartz
{
    public class QuartzShedulerHelper
    {
        public static async void Start()
        {
            IScheduler scheduler = await StdSchedulerFactory.GetDefaultScheduler();
            await scheduler.Start();

            IJobDetail job = JobBuilder.Create<TaskCreator>().Build();

            DateTime startTime = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day, 7, 13, 00);

            ITrigger trigger = TriggerBuilder.Create()  // создаем триггер
                .WithIdentity("sheduleTrigger", "mainGroup")     // идентифицируем триггер с именем и группой
                .StartAt(startTime)                            // запуск сразу после начала выполнения
                .WithSimpleSchedule(x => x            // настраиваем выполнение действия
                    .WithIntervalInHours(24)          // через 1 минуту
                    .RepeatForever())                   // бесконечное повторение
                .Build();                               // создаем триггер

            await scheduler.ScheduleJob(job, trigger);
        }

        public static async void NewShedule(IShedule shedule)
        {
            ISheduleManager sheduleManager = new SheduleManager();
            ISheduleTaskManager sheduleTaskManager = new SheduleTaskManager();
            if (shedule.PeriodCounter == shedule.Period)
            {
                try
                {
                    SheduleTask startTask = new SheduleTask();
                    startTask.StartDateTime = DateTime.UtcNow.Date + shedule.StartTime.TimeOfDay;
                    //startTask.Command = shedule.StartCommand;
                    await sheduleTaskManager.SaveAsync(startTask);

                    SheduleTask endTask = new SheduleTask();
                    endTask.StartDateTime = DateTime.UtcNow.Date + shedule.EndTime.TimeOfDay;
                    endTask.Command = shedule.EndCommand;
                    await sheduleTaskManager.SaveAsync(endTask);

                    shedule.LastExecutionTime = DateTime.UtcNow;

                    sheduleManager.Save(shedule);

                }
                catch (Exception)
                {

                }
            }
        }
    }
}
