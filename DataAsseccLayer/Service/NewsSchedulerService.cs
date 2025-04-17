using DataAsseccLayer.Concreat;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAsseccLayer.Service
{
    public class NewsSchedulerService : BackgroundService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        public NewsSchedulerService(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                    var now = DateTime.Now;

                    var pendingNews = context.News
                        .Where(n => n.status == 0 && n.ScheduledDate <= now && n.ScheduledDate != null)
                        .ToList();

                    foreach (var news in pendingNews)
                    {
                        news.status = 1; // avtomatik asosiy sahifaga o‘tadi
                    }

                    if (pendingNews.Any())
                        await context.SaveChangesAsync();
                }

                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken); // har 1 daqiqada tekshirish
            }
        }

    }
}
