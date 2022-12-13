using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamTask
{
    internal interface IWeaphon
    {
        int BulletCount { get; set; }
        int MagazineCapacity { get; set; }
        void Shoot();
        void Fire();
        int GetRemainBulletCount();
        void Reload();
        void ChangeFireMode();
        FireMode Mode { get; set; }
    }
}
