using System;
using System.Threading;
using System.Threading.Tasks;
using Birdhouse.Abstractions.Misc;
using Birdhouse.Tools.Updatables.Abstractions;

namespace Birdhouse.Tools.Updatables
{
    public abstract class UpdateValueFlowBase<T>
		: IFlow
	{
		protected UpdateValueFlowBase(IUpdatableValueWriter<T> writer, Func<T> creator, Func<bool> func)
		{
			_writer = writer;
			_creator = creator;
			_func = func;
		}
		
		private readonly IUpdatableValueWriter<T> _writer;
		private readonly Func<T> _creator;
		private readonly Func<bool> _func;

		private readonly CancellationTokenSource _source = new CancellationTokenSource();
            
		public async void Initialize()
		{
			while (true)
			{
				await Task.Yield();

				var isSuccess = _func.Invoke();
				if (isSuccess)
				{
					var value = _creator.Invoke();
					_writer.Update(value);
				}

				if (_source.IsCancellationRequested)
				{
					return;
				}
			}
		}

		public void Dispose()
		{
			_source.Cancel();
		}
	}
}