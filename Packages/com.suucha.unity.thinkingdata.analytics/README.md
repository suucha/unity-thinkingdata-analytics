# Suucha ADKU - ThinkingAnalytics


## 接入Suucha ADKU ThinkingAnalytics
修改Packages/manifest.json文件在dependencies中添加：
``` json
"dependencies": {
  "com.thinkingdata.analytics": "https://github.com/ThinkingDataAnalytics/unity-sdk.git",
  "com.suucha.unity.thinkingdata.analytics":"1.0.0"，

  //...
 }
```
> 数数github上master分支直接是upm包，但是是beta版，不是稳定版本，稳定版本需要在git url的后面加版本标签，比如：https://github.com/ThinkingDataAnalytics/unity-sdk.git#v2.6.0。不过2.6.0到3.X变化有点大，我们这个是以3.0的beta版来开发的。
## 开始
在实现了接口IAfterSuuchaInit的类的Execute方法中，用以下代码初始化ThinkingAnalytics和启用AppsFlyer的事件上报器：
``` csharp
public class AfterSuuchaInit: IAfterSuuchaInit
{
    public void Execute()
    {
        //初始化ThinkingAnalytics
        Suucha.App.InitThinkingAnalytics("your app id", "your server");
        //初始化ThinkingAnalytics Log Event Reproter并启用
        Suucha.App.InitThinkingAnalyticsReporter().Use();

        //其他逻辑
        // ...
    }
}
```
