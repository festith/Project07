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
            setup.monthForH2H = 36;
            setup.minValue = 0.01f;
            setup.maxValue = 0.05f;
            setup.minKf = 1f;
            setup.maxKf = 5f;
            setup.lampda = 0.13f;
            setup.kf = 1f;
            return setup;
        }

      //Sp+Por
      public static Setup GetSetupSpX()
      {
          var setup = new Setup();
          setup.daysForFormPeriod = 30;
          setup.monthForLevelPeriod = 36;
          setup.monthForH2H = 48;
          setup.minValue = 0.05f;
          setup.maxValue = 0.13f;
          setup.minKf = 1f;
          setup.maxKf = 5f;
          setup.lampda = 0.09f;
          setup.kf = 1f;
          return setup;
      }

      //Nl
      public static Setup GetSetupNlX()
      {
          var setup = new Setup();
          setup.daysForFormPeriod = 60;
          setup.monthForLevelPeriod = 36;
          setup.monthForH2H = 36;
          setup.minValue = 0.01f;
          setup.maxValue = 0.17f;
          setup.minKf = 1f;
          setup.maxKf = 4f;
          setup.lampda = 0.09f;
          setup.kf = 1f;
          return setup;
      }

      //It
      public static Setup GetSetupItX()
      {
          var setup = new Setup();
          setup.daysForFormPeriod = 90;
          setup.monthForLevelPeriod = 36;
          setup.monthForH2H = 36;
          setup.minValue = 0.01f;
          setup.maxValue = 0.08f;
          setup.minKf = 1f;
          setup.maxKf = 4f;
          setup.lampda = 0.07f;
          setup.kf = 1f;
          return setup;
      }

      //Ger
      public static Setup GetSetupGerX()
      {
          var setup = new Setup();
          setup.daysForFormPeriod = 60;
          setup.monthForLevelPeriod = 36;
          setup.monthForH2H = 24;
          setup.minValue = 0.02f;
          setup.maxValue = 0.19f;
          setup.minKf = 3f;
          setup.maxKf = 4.5f;
          setup.lampda = 0.18f;
          setup.kf = 1f;
          return setup;
      }

      //Fr1
      public static Setup GetSetupFrX()
      {
          var setup = new Setup();
          setup.daysForFormPeriod = 60;
          setup.monthForLevelPeriod = 24;
          setup.monthForH2H = 24;
          setup.minValue = 0.03f;
          setup.maxValue = 0.17f;
          setup.minKf = 1f;
          setup.maxKf = 4f;
          setup.lampda = 0.08f;
          setup.kf = 1f;
          return setup;
      }

      //En
      public static Setup GetSetupEnX()
      {
          var setup = new Setup();
          setup.daysForFormPeriod = 60;
          setup.monthForLevelPeriod = 24;
          setup.monthForH2H = 36;
          setup.minValue = 0.01f;
          setup.maxValue = 0.05f;
          setup.minKf = 1f;
          setup.maxKf = 4f;
          setup.lampda = 0.08f;
          setup.kf = 1f;
          return setup;
      }
    }
}
