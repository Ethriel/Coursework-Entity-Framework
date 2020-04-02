using BLL.Interface.Interfaces;
using System.Threading.Tasks;

namespace WPF_View.Windows.CRUD
{
    public static class RemoveEntity
    {
        public static async Task<bool> Remove<T>(IAdminInterface<T> adminInterface, T entity)
        {
            return await Task.Run(async () =>
            {
                var flag = false;
                await Task.Run(() => { adminInterface.RemoveAsync(entity); });
                flag = true;
                return flag;
            });
        }
    }
}
