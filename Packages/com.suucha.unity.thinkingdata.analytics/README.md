# Suucha ADKU - ThinkingAnalytics


## ����Suucha ADKU ThinkingAnalytics
�޸�Packages/manifest.json�ļ���dependencies����ӣ�
``` json
"dependencies": {
  "com.thinkingdata.analytics": "https://github.com/ThinkingDataAnalytics/unity-sdk.git",
  "com.suucha.unity.thinkingdata.analytics":"1.0.0"��

  //...
 }
```
> ����github��master��ֱ֧����upm����������beta�棬�����ȶ��汾���ȶ��汾��Ҫ��git url�ĺ���Ӱ汾��ǩ�����磺https://github.com/ThinkingDataAnalytics/unity-sdk.git#v2.6.0������2.6.0��3.X�仯�е�������������3.0��beta���������ġ�
## ��ʼ
��ʵ���˽ӿ�IAfterSuuchaInit�����Execute�����У������´����ʼ��ThinkingAnalytics������AppsFlyer���¼��ϱ�����
``` csharp
public class AfterSuuchaInit: IAfterSuuchaInit
{
    public void Execute()
    {
        //��ʼ��ThinkingAnalytics
        Suucha.App.InitThinkingAnalytics("your app id", "your server");
        //��ʼ��ThinkingAnalytics Log Event Reproter������
        Suucha.App.InitThinkingAnalyticsReporter().Use();

        //�����߼�
        // ...
    }
}
```
