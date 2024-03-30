using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting;
using MotoBikeShop.ViewComponents;
using System;
using System.Threading;
using System.Threading.Tasks;

public class BackgroundService : IHostedService, IDisposable
{
    private Timer _timer;
    private readonly IServiceProvider _serviceProvider;

    public BackgroundService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromMinutes(1));

        return Task.CompletedTask;
    }

    private void DoWork(object state)
    {
        using (var scope = _serviceProvider.CreateScope())
        {
            var viewComponentHelper = scope.ServiceProvider.GetRequiredService<IViewComponentHelper>();
            viewComponentHelper.InvokeAsync(typeof(ReviewViewComponent));
        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _timer?.Change(Timeout.Infinite, 0);

        return Task.CompletedTask;
    }

    public void Dispose()
    {
        _timer?.Dispose();
    }
}