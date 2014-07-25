﻿
namespace MobileSDKIntegrationTest
{
  using System;
  using System.Threading;
  using System.Threading.Tasks;

  using NUnit.Framework;
  using Sitecore.MobileSDK.API;
  using Sitecore.MobileSDK.API.Items;
  using Sitecore.MobileSDK.SessionSettings;
  using Sitecore.MobileSDK.Items;
  using Sitecore.MobileSDK;



  [TestFixture]
  public class OperationCancelTest
  {
    private ScTestApiSession session;
    private TestEnvironment env;
    private MediaLibrarySettings mediaSettings;

    [SetUp]
    public void SetUp()
    {
      this.env = TestEnvironment.DefaultTestEnvironment();

      this.mediaSettings = new MediaLibrarySettings(
        "/sitecore/media library",
        "ashx",
        "~/media/");

      var config = SessionConfig.NewAuthenticatedSessionConfig(this.env.InstanceUrl, this.env.Users.Admin.Username, this.env.Users.Admin.Password);
      var defaultSource = ItemSource.DefaultSource();

      this.session = new ScTestApiSession(config, config, mediaSettings, defaultSource);
    }

    [TearDown]
    public void TearDown()
    {
      this.session = null;
      this.env = null;
      this.mediaSettings = null;
    }


    [Test]
    public void TestCancelExceptionIsNotWrappedForGetPublicKeyRequest()
    {
      TestDelegate testAction = async () =>
      {
        var cancel = new CancellationTokenSource();

        Task<PublicKeyX509Certificate> action = this.session.GetPublicKeyAsyncPublic(cancel.Token);
        cancel.Cancel();

        await action;
      };
      Assert.Catch<OperationCanceledException>(testAction);
    }


    [Test]
    public void TestCancelExceptionIsNotWrappedForItemByIdRequest()
    {
      TestDelegate testAction = async () =>
      {
        var cancel = new CancellationTokenSource();
        var request = ItemWebApiRequestBuilder.ReadItemsRequestWithId(this.env.Items.Home.Id).Build();

        Task<ScItemsResponse> action = this.session.ReadItemAsync(request, cancel.Token);
        cancel.Cancel();

        await action;
      };
      Assert.Catch<OperationCanceledException>(testAction);
    }



    [Test]
    public void TestCancelExceptionIsNotWrappedForItemByPathRequest()
    {
      TestDelegate testAction = async () =>
      {
        var cancel = new CancellationTokenSource ();
        var request = ItemWebApiRequestBuilder.ReadItemsRequestWithPath("/sitecore/content/home").Build();

        Task<ScItemsResponse> action = this.session.ReadItemAsync(request, cancel.Token);
        cancel.Cancel();

        await action;
      };
      Assert.Catch<OperationCanceledException>(testAction);
    }


    [Test]
    public void TestCancelExceptionIsNotWrappedForItemByQueryRequest()
    {
      TestDelegate testAction = async () =>
      {
        var cancel = new CancellationTokenSource();
        var request = ItemWebApiRequestBuilder.ReadItemsRequestWithSitecoreQuery("/sitecore/content/home/*").Build();

        Task<ScItemsResponse> action = this.session.ReadItemAsync(request, cancel.Token);
        cancel.Cancel();

        await action;
      };
      Assert.Catch<OperationCanceledException>(testAction);
    }
  }
}

