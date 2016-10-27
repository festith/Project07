using ConsoleApplication1.SystemSetup;

namespace ConsoleApplication1
{
  public static  class SetupsProvider
    {

      public static class SetupsW2
      {
          //En
          public static Setup GetSetupEnW2()
          {
              var setup = new Setup();
              setup.daysForFormPeriod = 30;
              setup.monthForLevelPeriod = 36;
              setup.monthForH2H = 24;
              setup.minValue = 0.03f;
              setup.maxValue = 0.19f;
              setup.minKf = 1f;
              setup.maxKf = 5f;
              setup.lampda = 0.14f;
              setup.kf = 1f;
              return setup;
          }

          //Fr1 + Fr2
          public static Setup GetSetupFrW2()
          {
              var setup = new Setup();
              setup.daysForFormPeriod = 30;
              setup.monthForLevelPeriod = 48;
              setup.monthForH2H = 36;
              setup.minValue = 0.03f;
              setup.maxValue = 0.17f;
              setup.minKf = 1f;
              setup.maxKf = 5f;
              setup.lampda = 0.07f;
              setup.kf = 1f;
              return setup;
          }

          //Ger
          public static Setup GetSetupGerW2()
          {
              var setup = new Setup();
              setup.daysForFormPeriod = 90;
              setup.monthForLevelPeriod = 36;
              setup.monthForH2H = 36;
              setup.minValue = 0.01f;
              setup.maxValue = 0.19f;
              setup.minKf = 1f;
              setup.maxKf = 5f;
              setup.lampda = 0.17f;
              setup.kf = 1f;
              return setup;
          }

          //It + Fr1
          public static Setup GetSetupItW2()
          {
              var setup = new Setup();
              setup.daysForFormPeriod = 90;
              setup.monthForLevelPeriod = 36;
              setup.monthForH2H = 48;
              setup.minValue = 0.03f;
              setup.maxValue = 0.13f;
              setup.minKf = 1f;
              setup.maxKf = 5f;
              setup.lampda = 0.17f;
              setup.kf = 1f;
              return setup;
          }

          //Nl
          public static Setup GetSetupNlW2()
          {
              var setup = new Setup();
              setup.daysForFormPeriod = 60;
              setup.monthForLevelPeriod = 24;
              setup.monthForH2H = 48;
              setup.minValue = 0.01f;
              setup.maxValue = 0.19f;
              setup.minKf = 1f;
              setup.maxKf = 4f;
              setup.lampda = 0.14f;
              setup.kf = 1f;
              return setup;
          }

          //Por + Sp
          public static Setup GetSetupPorW2()
          {
              var setup = new Setup();
              setup.daysForFormPeriod = 90;
              setup.monthForLevelPeriod = 24;
              setup.monthForH2H = 24;
              setup.minValue = 0.01f;
              setup.maxValue = 0.22f;
              setup.minKf = 1f;
              setup.maxKf = 5f;
              setup.lampda = 0.225f;
              setup.kf = 1f;
              return setup;
          }

          //Sp
          public static Setup GetSetupSpW2()
          {
              var setup = new Setup();
              setup.daysForFormPeriod = 60;
              setup.monthForLevelPeriod = 24;
              setup.monthForH2H = 48;
              setup.minValue = 0.03f;
              setup.maxValue = 0.19f;
              setup.minKf = 1f;
              setup.maxKf = 5f;
              setup.lampda = 0.08f;
              setup.kf = 1f;
              return setup;
          }
      }

      public static class SetupsW1
      {
          //En
          public static Setup GetSetupEnW1()
          {
              var setup = new Setup();
              setup.daysForFormPeriod = 30;
              setup.monthForLevelPeriod = 48;
              setup.monthForH2H = 48;
              setup.minValue = 0.01f;
              setup.maxValue = 0.11f;
              setup.minKf = 1f;
              setup.maxKf = 4f;
              setup.lampda = 0.11f;
              setup.kf = 1f;
              return setup;
          }

          //Fr + Nl
          public static Setup GetSetupFrW1()
          {
              var setup = new Setup();
              setup.daysForFormPeriod = 60;
              setup.monthForLevelPeriod = 24;
              setup.monthForH2H = 48;
              setup.minValue = 0.03f;
              setup.maxValue = 0.17f;
              setup.minKf = 1f;
              setup.maxKf = 3f;
              setup.lampda = 0.11f;
              setup.kf = 1f;
              return setup;
          }

          //Ger
          public static Setup GetSetupGerW1()
          {
              var setup = new Setup();
              setup.daysForFormPeriod = 60;
              setup.monthForLevelPeriod = 48;
              setup.monthForH2H = 24;
              setup.minValue = 0.01f;
              setup.maxValue = 0.11f;
              setup.minKf = 1f;
              setup.maxKf = 4.5f;
              setup.lampda = 0.17f;
              setup.kf = 1f;
              return setup;
          }

          //It + Fr1
          public static Setup GetSetupItW1()
          {
              var setup = new Setup();
              setup.daysForFormPeriod = 90;
              setup.monthForLevelPeriod = 48;
              setup.monthForH2H = 36;
              setup.minValue = 0.01f;
              setup.maxValue = 0.07f;
              setup.minKf = 1f;
              setup.maxKf = 4f;
              setup.lampda = 0.13f;
              setup.kf = 1f;
              return setup;
          }

          //Nl + Fr1
          public static Setup GetSetupNlW1()
          {
              var setup = new Setup();
              setup.daysForFormPeriod = 60;
              setup.monthForLevelPeriod = 36;
              setup.monthForH2H = 24;
              setup.minValue = 0.01f;
              setup.maxValue = 0.13f;
              setup.minKf = 2f;
              setup.maxKf = 5f;
              setup.lampda = 0.14f;
              setup.kf = 1f;
              return setup;
          }

          //Por
          public static Setup GetSetupPorW1()
          {
              var setup = new Setup();
              setup.daysForFormPeriod = 90;
              setup.monthForLevelPeriod = 36;
              setup.monthForH2H = 48;
              setup.minValue = 0.05f;
              setup.maxValue = 0.19f;
              setup.minKf = 1f;
              setup.maxKf = 3f;
              setup.lampda = 0.17f;
              setup.kf = 1f;
              return setup;
          }

          //Sp
          public static Setup GetSetupSpW1()
          {
              var setup = new Setup();
              setup.daysForFormPeriod = 90;
              setup.monthForLevelPeriod = 24;
              setup.monthForH2H = 48;
              setup.minValue = 0.03f;
              setup.maxValue = 0.17f;
              setup.minKf = 2f;
              setup.maxKf = 4f;
              setup.lampda = 0.12f;
              setup.kf = 1f;
              return setup;
          }
      }


      public static Setup GetSetupTest()
        {
            var setup = new Setup();
            setup.daysForFormPeriod = 30;
            setup.monthForLevelPeriod = 36;
            setup.monthForH2H = 24;
            setup.minValue = 0.03f;
            setup.maxValue = 0.19f;
            setup.minKf = 1f;
            setup.maxKf = 5f;
            setup.lampda = 0.14f;
            setup.kf = 1f;
            return setup;
        }
           

      public static class SetupsX
      {
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
}
