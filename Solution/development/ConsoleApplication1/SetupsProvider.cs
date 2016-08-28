using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1.SystemSetup;

namespace ConsoleApplication1
{
  public static  class SetupsProvider
    {
      public static Setup GetSetupTest()
        {
            var setup = new Setup();
            setup.daysForFormPeriod = 30;
            setup.monthForLevelPeriod = 48;
            setup.monthForH2H = 48;
            setup.minValue = 0.05f;
            setup.maxValue = 0.11f;
            setup.minKf = 2f;
            setup.maxKf = 4f;
            setup.lampda = 0.1f;
            setup.kf = 1f;
            return setup;
        }

      public static Setup GetSetupEn()
        {
            var setup = new Setup();
            setup.daysForFormPeriod = 30;
            setup.monthForH2H = 36;
            setup.monthForLevelPeriod = 48;
            setup.minValue = 0.03f;
            setup.maxValue = 0.09f;
            setup.minKf = 1f;
            setup.maxKf = 4f;
            setup.lampda = 0.09f;
            setup.kf = 1f;
            return setup;
        }

      public static Setup GetSetupSp()
        {
            var setup = new Setup();
            setup.daysForFormPeriod = 30;
            setup.monthForH2H = 48;
            setup.monthForLevelPeriod = 36;
            setup.minValue = 0.01f;
            setup.maxValue = 0.12f;
            setup.minKf = 3f;
            setup.maxKf = 5f;
            setup.lampda = 0.065f;
            setup.kf = 1f;
            return setup;
        }

      public static Setup GetSetupIt()
        {
            var setup = new Setup();
            setup.daysForFormPeriod = 30;
            setup.monthForLevelPeriod = 48;
            setup.monthForH2H = 36;
            setup.minValue = 0.03f;
            setup.maxValue = 0.09f;
            setup.minKf = 1f;
            setup.maxKf = 5f;
            setup.lampda = 0.08f;
            setup.kf = 1f;
            return setup;
        }

      public static Setup GetSetupFr2()
        {
            var setup = new Setup();
            setup.daysForFormPeriod = 30;
            setup.monthForH2H = 36;
            setup.monthForLevelPeriod = 36;
            setup.minValue = 0.03f;
            setup.maxValue = 0.07f;
            setup.minKf = 1f;
            setup.maxKf = 4f;
            setup.lampda = 0.1f;
            setup.kf = 1f;
            return setup;
        }

      public static Setup GetSetupFr1()
        {
            var setup = new Setup();
            setup.daysForFormPeriod = 60;
            setup.monthForLevelPeriod = 36;
            setup.monthForH2H = 24;
            setup.minValue = 0.01f;
            setup.maxValue = 0.03f;
            setup.minKf = 1f;
            setup.maxKf = 4f;
            setup.lampda = 0.12f;
            setup.kf = 1f;
            return setup;
        }

      public static Setup GetSetupGer()
        {
            var setup = new Setup();
            setup.daysForFormPeriod = 90;
            setup.monthForLevelPeriod = 24;
            setup.monthForH2H = 48;
            setup.minValue = 0.03f;
            setup.maxValue = 0.15f;
            setup.minKf = 1f;
            setup.maxKf = 4f;
            setup.lampda = 0.1f;
            setup.kf = 1f;
            return setup;
        }

      public static Setup GetSetupIsr()
        {
            var setup = new Setup();
            setup.daysForFormPeriod = 90;
            setup.monthForLevelPeriod = 48;
            setup.monthForH2H = 24;
            setup.minValue = 0.05f;
            setup.maxValue = 0.15f;
            setup.minKf = 1f;
            setup.maxKf = 5f;
            setup.lampda = 0.12f;
            setup.kf = 1f;
            return setup;
        }

      public static Setup GetSetupNl()
        {
            var setup = new Setup();
            setup.daysForFormPeriod = 90;
            setup.monthForLevelPeriod = 36;
            setup.monthForH2H = 36;
            setup.minValue = 0.01f;
            setup.maxValue = 0.13f;
            setup.minKf = 1f;
            setup.maxKf = 5f;
            setup.lampda = 0.07f;
            setup.kf = 1;
            return setup;
        }

      public static Setup GetSetupPor()
        {
            var setup = new Setup();
            setup.daysForFormPeriod = 90;
            setup.monthForLevelPeriod = 48;
            setup.monthForH2H = 48;
            setup.minValue = 0.01f;
            setup.maxValue = 0.05f;
            setup.minKf = 1f;
            setup.maxKf = 4f;
            setup.lampda = 0.1f;
            setup.kf = 1f;
            return setup;
        }

      public static Setup GetSetupSwitz()
        {
            var setup = new Setup();
            setup.daysForFormPeriod = 30;
            setup.monthForLevelPeriod = 24;
            setup.monthForH2H = 36;
            setup.minValue = 0.02f;
            setup.maxValue = 0.1f;
            setup.minKf = 2f;
            setup.maxKf = 6f;
            setup.lampda = 0.11f;
            setup.kf = 1f;
            return setup;
        }

      public static Setup GetSetupTur()
        {
            var setup = new Setup();
            setup.daysForFormPeriod = 75;
            setup.monthForLevelPeriod = 48;
            setup.monthForH2H = 48;
            setup.minValue = 0.01f;
            setup.maxValue = 0.05f;
            setup.minKf = 1f;
            setup.maxKf = 4f;
            setup.lampda = 0.1f;
            setup.kf = 1f;
            return setup;
        }

      public static Setup GetSetupDen()
        {
            var setup = new Setup();
            setup.daysForFormPeriod = 60;
            setup.monthForLevelPeriod = 24;
            setup.monthForH2H = 24;
            setup.minValue = 0.02f;
            setup.maxValue = 0.1f;
            setup.minKf = 1f;
            setup.maxKf = 4f;
            setup.lampda = 0.14f;
            setup.kf = 1f;
            return setup;
        }

      public static Setup GetSetupBel()
        {
            var setup = new Setup();
            setup.daysForFormPeriod = 90;
            setup.monthForLevelPeriod = 24;
            setup.monthForH2H = 48;
            setup.minValue = 0.03f;
            setup.maxValue = 0.09f;
            setup.minKf = 1f;
            setup.maxKf = 5f;
            setup.lampda = 0.1f;
            setup.kf = 1f;
            return setup;
        }

      public static Setup GetSetupAus()
        {
            var setup = new Setup();
            setup.daysForFormPeriod = 45;
            setup.monthForLevelPeriod = 24;
            setup.monthForH2H = 24;
            setup.minValue = 0.02f;
            setup.maxValue = 0.1f;
            setup.minKf = 2f;
            setup.maxKf = 4f;
            setup.lampda = 0.11f;
            setup.kf = 1f;
            return setup;
        }

      public static Setup GetSetupScot()
        {
            var setup = new Setup();
            setup.daysForFormPeriod = 90;
            setup.monthForLevelPeriod = 48;
            setup.monthForH2H = 36;
            setup.minValue = 0.01f;
            setup.maxValue = 0.05f;
            setup.minKf = 1f;
            setup.maxKf = 5f;
            setup.lampda = 0.1f;
            setup.kf = 1f;
            return setup;
        }

      public static Setup GetSetupCzech()
        {
            var setup = new Setup();
            setup.daysForFormPeriod = 30;
            setup.monthForLevelPeriod = 24;
            setup.monthForH2H = 36;
            setup.minValue = 0.02f;
            setup.maxValue = 0.1f;
            setup.minKf = 1f;
            setup.maxKf = 6f;
            setup.lampda = 0.09f;
            setup.kf = 1f;
            return setup;
        }
    }
}
