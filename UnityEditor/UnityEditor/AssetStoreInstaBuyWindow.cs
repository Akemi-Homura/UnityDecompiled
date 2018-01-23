﻿// Decompiled with JetBrains decompiler
// Type: UnityEditor.AssetStoreInstaBuyWindow
// Assembly: UnityEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 53BAA40C-AA1D-48D3-AA10-3FCF36D212BC
// Assembly location: C:\Program Files\Unity 5\Editor\Data\Managed\UnityEditor.dll

using UnityEditorInternal;
using UnityEngine;

namespace UnityEditor
{
  internal class AssetStoreInstaBuyWindow : EditorWindow
  {
    private string m_Password = "";
    private AssetStoreAsset m_Asset = (AssetStoreAsset) null;
    private string m_Message = "";
    private AssetStoreInstaBuyWindow.PurchaseStatus m_Purchasing = AssetStoreInstaBuyWindow.PurchaseStatus.Init;
    private double m_NextAllowedBuildRequestTime = 0.0;
    private int m_BuildAttempts = 0;
    private string m_PurchaseMessage = (string) null;
    private string m_PaymentMethodCard = (string) null;
    private string m_PaymentMethodExpire = (string) null;
    private string m_PriceText = (string) null;
    private const int kStandardHeight = 160;
    private static GUIContent s_AssetStoreLogo;
    private const double kBuildPollInterval = 2.0;
    private const int kMaxPolls = 150;

    public static AssetStoreInstaBuyWindow ShowAssetStoreInstaBuyWindow(AssetStoreAsset asset, string purchaseMessage, string paymentMethodCard, string paymentMethodExpire, string priceText)
    {
      AssetStoreInstaBuyWindow windowWithRect = EditorWindow.GetWindowWithRect<AssetStoreInstaBuyWindow>(new Rect(100f, 100f, 400f, 160f), true, "Buy package from Asset Store");
      if (windowWithRect.m_Purchasing != AssetStoreInstaBuyWindow.PurchaseStatus.Init)
      {
        EditorUtility.DisplayDialog("Download in progress", "There is already a package download in progress. You can only have one download running at a time", "Close");
        return windowWithRect;
      }
      windowWithRect.position = new Rect(100f, 100f, 400f, 160f);
      windowWithRect.m_Parent.window.m_DontSaveToLayout = true;
      windowWithRect.m_Asset = asset;
      windowWithRect.m_Password = "";
      windowWithRect.m_Message = "";
      windowWithRect.m_Purchasing = AssetStoreInstaBuyWindow.PurchaseStatus.Init;
      windowWithRect.m_NextAllowedBuildRequestTime = 0.0;
      windowWithRect.m_BuildAttempts = 0;
      windowWithRect.m_PurchaseMessage = purchaseMessage;
      windowWithRect.m_PaymentMethodCard = paymentMethodCard;
      windowWithRect.m_PaymentMethodExpire = paymentMethodExpire;
      windowWithRect.m_PriceText = priceText;
      UsabilityAnalytics.Track(string.Format("/AssetStore/ShowInstaBuy/{0}/{1}", (object) windowWithRect.m_Asset.packageID, (object) windowWithRect.m_Asset.id));
      return windowWithRect;
    }

    public static void ShowAssetStoreInstaBuyWindowBuilding(AssetStoreAsset asset)
    {
      AssetStoreInstaBuyWindow storeInstaBuyWindow = AssetStoreInstaBuyWindow.ShowAssetStoreInstaBuyWindow(asset, "", "", "", "");
      if (storeInstaBuyWindow.m_Purchasing != AssetStoreInstaBuyWindow.PurchaseStatus.Init)
      {
        EditorUtility.DisplayDialog("Download in progress", "There is already a package download in progress. You can only have one download running at a time", "Close");
      }
      else
      {
        storeInstaBuyWindow.m_Purchasing = AssetStoreInstaBuyWindow.PurchaseStatus.StartBuild;
        storeInstaBuyWindow.m_BuildAttempts = 1;
        asset.previewInfo.buildProgress = 0.0f;
        UsabilityAnalytics.Track(string.Format("/AssetStore/ShowInstaFree/{0}/{1}", (object) storeInstaBuyWindow.m_Asset.packageID, (object) storeInstaBuyWindow.m_Asset.id));
      }
    }

    private static void LoadLogos()
    {
      if (AssetStoreInstaBuyWindow.s_AssetStoreLogo != null)
        return;
      AssetStoreInstaBuyWindow.s_AssetStoreLogo = EditorGUIUtility.IconContent("WelcomeScreen.AssetStoreLogo");
    }

    public void OnInspectorUpdate()
    {
      if (this.m_Purchasing != AssetStoreInstaBuyWindow.PurchaseStatus.StartBuild || this.m_NextAllowedBuildRequestTime > EditorApplication.timeSinceStartup)
        return;
      this.m_NextAllowedBuildRequestTime = EditorApplication.timeSinceStartup + 2.0;
      this.BuildPackage();
    }

    private void OnEnable()
    {
      AssetStoreUtils.RegisterDownloadDelegate((ScriptableObject) this);
    }

    public void OnDisable()
    {
      AssetStoreAsset.PreviewInfo previewInfo = this.m_Asset != null ? this.m_Asset.previewInfo : (AssetStoreAsset.PreviewInfo) null;
      if (previewInfo != null)
      {
        previewInfo.downloadProgress = -1f;
        previewInfo.buildProgress = -1f;
      }
      AssetStoreUtils.UnRegisterDownloadDelegate((ScriptableObject) this);
      this.m_Purchasing = AssetStoreInstaBuyWindow.PurchaseStatus.Init;
    }

    public void OnDownloadProgress(string id, string message, int bytes, int total)
    {
      AssetStoreAsset.PreviewInfo previewInfo = this.m_Asset != null ? this.m_Asset.previewInfo : (AssetStoreAsset.PreviewInfo) null;
      if (previewInfo == null || this.m_Asset.packageID.ToString() != id)
        return;
      previewInfo.downloadProgress = message == "downloading" || message == "connecting" ? (float) bytes / (float) total : -1f;
      this.Repaint();
    }

    public void OnGUI()
    {
      AssetStoreInstaBuyWindow.LoadLogos();
      if (this.m_Asset == null)
        return;
      GUILayout.BeginVertical();
      GUILayout.Space(10f);
      switch (this.m_Purchasing)
      {
        case AssetStoreInstaBuyWindow.PurchaseStatus.Init:
          this.PasswordGUI();
          break;
        case AssetStoreInstaBuyWindow.PurchaseStatus.InProgress:
          if (this.m_Purchasing == AssetStoreInstaBuyWindow.PurchaseStatus.InProgress)
            GUI.enabled = false;
          this.PasswordGUI();
          break;
        case AssetStoreInstaBuyWindow.PurchaseStatus.Declined:
          this.PurchaseDeclinedGUI();
          break;
        case AssetStoreInstaBuyWindow.PurchaseStatus.Complete:
          this.PurchaseSuccessGUI();
          break;
        case AssetStoreInstaBuyWindow.PurchaseStatus.StartBuild:
        case AssetStoreInstaBuyWindow.PurchaseStatus.Building:
        case AssetStoreInstaBuyWindow.PurchaseStatus.Downloading:
          this.DownloadingGUI();
          break;
      }
      GUILayout.EndVertical();
    }

    private void PasswordGUI()
    {
      AssetStoreAsset.PreviewInfo previewInfo = this.m_Asset.previewInfo;
      GUILayout.BeginHorizontal();
      GUILayout.Space(5f);
      GUILayout.Label(AssetStoreInstaBuyWindow.s_AssetStoreLogo, GUIStyle.none, new GUILayoutOption[1]
      {
        GUILayout.ExpandWidth(false)
      });
      GUILayout.BeginVertical();
      GUILayout.Label("Complete purchase by entering your AssetStore password", EditorStyles.boldLabel, new GUILayoutOption[0]);
      bool flag1 = this.m_PurchaseMessage != null && this.m_PurchaseMessage != "";
      bool flag2 = this.m_Message != null && this.m_Message != "";
      float height = (float) (160 + (!flag1 ? 0 : 20) + (!flag2 ? 0 : 20));
      if ((double) height != (double) this.position.height)
        this.position = new Rect(this.position.x, this.position.y, this.position.width, height);
      if (flag1)
        GUILayout.Label(this.m_PurchaseMessage, EditorStyles.wordWrappedLabel, new GUILayoutOption[0]);
      if (flag2)
      {
        Color color = GUI.color;
        GUI.color = Color.red;
        GUILayout.Label(this.m_Message, EditorStyles.wordWrappedLabel, new GUILayoutOption[0]);
        GUI.color = color;
      }
      GUILayout.Label("Package: " + previewInfo.packageName, EditorStyles.wordWrappedLabel, new GUILayoutOption[0]);
      GUILayout.Label(string.Format("Credit card: {0} (expires {1})", (object) this.m_PaymentMethodCard, (object) this.m_PaymentMethodExpire), EditorStyles.wordWrappedLabel, new GUILayoutOption[0]);
      GUILayout.Space(8f);
      EditorGUILayout.LabelField("Amount", this.m_PriceText, new GUILayoutOption[0]);
      this.m_Password = EditorGUILayout.PasswordField("Password", this.m_Password, new GUILayoutOption[0]);
      GUILayout.EndVertical();
      GUILayout.Space(5f);
      GUILayout.EndHorizontal();
      GUILayout.FlexibleSpace();
      GUILayout.BeginHorizontal();
      GUILayout.Space(8f);
      if (GUILayout.Button("Just put to basket..."))
      {
        AssetStore.Open(string.Format("content/{0}/basketpurchase", (object) this.m_Asset.packageID));
        UsabilityAnalytics.Track(string.Format("/AssetStore/PutToBasket/{0}/{1}", (object) this.m_Asset.packageID, (object) this.m_Asset.id));
        this.m_Asset = (AssetStoreAsset) null;
        this.Close();
        GUIUtility.ExitGUI();
      }
      GUILayout.FlexibleSpace();
      if (GUILayout.Button("Cancel"))
      {
        UsabilityAnalytics.Track(string.Format("/AssetStore/CancelInstaBuy/{0}/{1}", (object) this.m_Asset.packageID, (object) this.m_Asset.id));
        this.m_Asset = (AssetStoreAsset) null;
        this.Close();
        GUIUtility.ExitGUI();
      }
      GUILayout.Space(5f);
      if (GUILayout.Button("Complete purchase"))
        this.CompletePurchase();
      GUILayout.Space(5f);
      GUILayout.EndHorizontal();
      GUILayout.Space(5f);
    }

    private void PurchaseSuccessGUI()
    {
      AssetStoreAsset.PreviewInfo previewInfo = this.m_Asset.previewInfo;
      GUILayout.BeginHorizontal();
      GUILayout.Space(5f);
      GUILayout.Label(AssetStoreInstaBuyWindow.s_AssetStoreLogo, GUIStyle.none, new GUILayoutOption[1]
      {
        GUILayout.ExpandWidth(false)
      });
      GUILayout.BeginVertical();
      GUILayout.Label("Purchase completed succesfully", EditorStyles.boldLabel, new GUILayoutOption[0]);
      GUILayout.Label("You will receive a receipt in your email soon.");
      bool flag = this.m_Message != null && this.m_Message != "";
      float height = (float) (160 + (!flag ? 0 : 20));
      if ((double) height != (double) this.position.height)
        this.position = new Rect(this.position.x, this.position.y, this.position.width, height);
      if (flag)
        GUILayout.Label(this.m_Message, EditorStyles.wordWrappedLabel, new GUILayoutOption[0]);
      GUILayout.Label("Package: " + previewInfo.packageName, EditorStyles.wordWrappedLabel, new GUILayoutOption[0]);
      GUILayout.EndVertical();
      GUILayout.Space(5f);
      GUILayout.EndHorizontal();
      GUILayout.FlexibleSpace();
      GUILayout.BeginHorizontal();
      GUILayout.Space(8f);
      GUILayout.FlexibleSpace();
      if (GUILayout.Button("Close"))
      {
        UsabilityAnalytics.Track(string.Format("/AssetStore/PurchaseOk/{0}/{1}", (object) this.m_Asset.packageID, (object) this.m_Asset.id));
        this.m_Asset = (AssetStoreAsset) null;
        this.Close();
      }
      GUILayout.Space(5f);
      if (GUILayout.Button("Import package"))
      {
        UsabilityAnalytics.Track(string.Format("/AssetStore/PurchaseOkImport/{0}/{1}", (object) this.m_Asset.packageID, (object) this.m_Asset.id));
        this.m_BuildAttempts = 1;
        this.m_Asset.previewInfo.buildProgress = 0.0f;
        this.m_Purchasing = AssetStoreInstaBuyWindow.PurchaseStatus.StartBuild;
      }
      GUILayout.Space(5f);
      GUILayout.EndHorizontal();
      GUILayout.Space(5f);
    }

    private void DownloadingGUI()
    {
      AssetStoreAsset.PreviewInfo previewInfo = this.m_Asset.previewInfo;
      GUILayout.BeginHorizontal();
      GUILayout.Space(5f);
      GUILayout.Label(AssetStoreInstaBuyWindow.s_AssetStoreLogo, GUIStyle.none, new GUILayoutOption[1]
      {
        GUILayout.ExpandWidth(false)
      });
      GUILayout.BeginVertical();
      GUILayout.Label("Importing", EditorStyles.boldLabel, new GUILayoutOption[0]);
      GUILayout.Label("Package: " + previewInfo.packageName, EditorStyles.wordWrappedLabel, new GUILayoutOption[0]);
      GUILayout.Label("    ");
      if (Event.current.type == EventType.Repaint)
      {
        Rect lastRect = GUILayoutUtility.GetLastRect();
        ++lastRect.height;
        bool flag = (double) previewInfo.downloadProgress >= 0.0;
        EditorGUI.ProgressBar(lastRect, !flag ? previewInfo.buildProgress : previewInfo.downloadProgress, !flag ? "Building" : "Downloading");
      }
      GUILayout.EndVertical();
      GUILayout.Space(5f);
      GUILayout.EndHorizontal();
      GUILayout.FlexibleSpace();
      GUILayout.BeginHorizontal();
      GUILayout.FlexibleSpace();
      if (GUILayout.Button("Abort"))
        this.Close();
      GUILayout.Space(5f);
      GUILayout.EndHorizontal();
      GUILayout.Space(5f);
    }

    private void PurchaseDeclinedGUI()
    {
      AssetStoreAsset.PreviewInfo previewInfo = this.m_Asset.previewInfo;
      GUILayout.BeginHorizontal();
      GUILayout.Space(5f);
      GUILayout.Label(AssetStoreInstaBuyWindow.s_AssetStoreLogo, GUIStyle.none, new GUILayoutOption[1]
      {
        GUILayout.ExpandWidth(false)
      });
      GUILayout.BeginVertical();
      GUILayout.Label("Purchase declined", EditorStyles.boldLabel, new GUILayoutOption[0]);
      GUILayout.Label("No money has been drawn from you credit card");
      bool flag = this.m_Message != null && this.m_Message != "";
      float height = (float) (160 + (!flag ? 0 : 20));
      if ((double) height != (double) this.position.height)
        this.position = new Rect(this.position.x, this.position.y, this.position.width, height);
      if (flag)
        GUILayout.Label(this.m_Message, EditorStyles.wordWrappedLabel, new GUILayoutOption[0]);
      GUILayout.Label("Package: " + previewInfo.packageName, EditorStyles.wordWrappedLabel, new GUILayoutOption[0]);
      GUILayout.EndVertical();
      GUILayout.Space(5f);
      GUILayout.EndHorizontal();
      GUILayout.FlexibleSpace();
      GUILayout.BeginHorizontal();
      GUILayout.Space(8f);
      GUILayout.FlexibleSpace();
      if (GUILayout.Button("Close"))
      {
        UsabilityAnalytics.Track(string.Format("/AssetStore/DeclinedAbort/{0}/{1}", (object) this.m_Asset.packageID, (object) this.m_Asset.id));
        this.m_Asset = (AssetStoreAsset) null;
        this.Close();
      }
      GUILayout.Space(5f);
      if (GUILayout.Button("Put to basket"))
      {
        AssetStore.Open(string.Format("content/{0}/basketpurchase", (object) this.m_Asset.packageID));
        UsabilityAnalytics.Track(string.Format("/AssetStore/DeclinedPutToBasket/{0}/{1}", (object) this.m_Asset.packageID, (object) this.m_Asset.id));
        this.m_Asset = (AssetStoreAsset) null;
        this.Close();
      }
      GUILayout.Space(5f);
      GUILayout.EndHorizontal();
      GUILayout.Space(5f);
    }

    private void CompletePurchase()
    {
      this.m_Message = "";
      string password = this.m_Password;
      this.m_Password = "";
      this.m_Purchasing = AssetStoreInstaBuyWindow.PurchaseStatus.InProgress;
      AssetStoreClient.DirectPurchase(this.m_Asset.packageID, password, (AssetStoreResultBase<PurchaseResult>.Callback) (result =>
      {
        this.m_Purchasing = AssetStoreInstaBuyWindow.PurchaseStatus.Init;
        if (result.error != null)
        {
          this.m_Purchasing = AssetStoreInstaBuyWindow.PurchaseStatus.Declined;
          this.m_Message = "An error occurred while completing you purhase.";
          this.Close();
        }
        string str = (string) null;
        switch (result.status)
        {
          case PurchaseResult.Status.BasketNotEmpty:
            this.m_Message = "Something else has been put in our Asset Store basket while doing this purchase.";
            this.m_Purchasing = AssetStoreInstaBuyWindow.PurchaseStatus.Declined;
            break;
          case PurchaseResult.Status.ServiceDisabled:
            this.m_Message = "Single click purchase has been disabled while doing this purchase.";
            this.m_Purchasing = AssetStoreInstaBuyWindow.PurchaseStatus.Declined;
            break;
          case PurchaseResult.Status.AnonymousUser:
            this.m_Message = "You have been logged out from somewhere else while doing this purchase.";
            this.m_Purchasing = AssetStoreInstaBuyWindow.PurchaseStatus.Declined;
            break;
          case PurchaseResult.Status.PasswordMissing:
            this.m_Message = result.message;
            this.Repaint();
            break;
          case PurchaseResult.Status.PasswordWrong:
            this.m_Message = result.message;
            this.Repaint();
            break;
          case PurchaseResult.Status.PurchaseDeclined:
            this.m_Purchasing = AssetStoreInstaBuyWindow.PurchaseStatus.Declined;
            if (result.message != null)
              this.m_Message = result.message;
            this.Repaint();
            break;
          case PurchaseResult.Status.Ok:
            this.m_Purchasing = AssetStoreInstaBuyWindow.PurchaseStatus.Complete;
            if (result.message != null)
              this.m_Message = result.message;
            this.Repaint();
            break;
        }
        if (str == null)
          return;
        EditorUtility.DisplayDialog("Purchase failed", str + " This purchase has been cancelled.", "Add this item to basket", "Cancel");
      }));
      UsabilityAnalytics.Track(string.Format("/AssetStore/InstaBuy/{0}/{1}", (object) this.m_Asset.packageID, (object) this.m_Asset.id));
    }

    private void BuildPackage()
    {
      AssetStoreAsset.PreviewInfo previewInfo = this.m_Asset.previewInfo;
      if (previewInfo == null)
        return;
      if (this.m_BuildAttempts++ > 150)
      {
        EditorUtility.DisplayDialog("Building timed out", "Timed out during building of package", "Close");
        this.Close();
      }
      else
      {
        previewInfo.downloadProgress = -1f;
        this.m_Purchasing = AssetStoreInstaBuyWindow.PurchaseStatus.Building;
        AssetStoreClient.BuildPackage(this.m_Asset, (AssetStoreResultBase<BuildPackageResult>.Callback) (result =>
        {
          if ((Object) this == (Object) null)
            return;
          if (result.error != null)
          {
            Debug.Log((object) result.error);
            if (!EditorUtility.DisplayDialog("Error building package", "The server was unable to build the package. Please re-import.", "Ok"))
              return;
            this.Close();
          }
          else
          {
            if (this.m_Asset == null || this.m_Purchasing != AssetStoreInstaBuyWindow.PurchaseStatus.Building || result.packageID != this.m_Asset.packageID)
              this.Close();
            string packageUrl = result.asset.previewInfo.packageUrl;
            if (packageUrl != null && packageUrl != "")
              this.DownloadPackage();
            else
              this.m_Purchasing = AssetStoreInstaBuyWindow.PurchaseStatus.StartBuild;
            this.Repaint();
          }
        }));
      }
    }

    private void DownloadPackage()
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      AssetStoreInstaBuyWindow.\u003CDownloadPackage\u003Ec__AnonStorey0 packageCAnonStorey0 = new AssetStoreInstaBuyWindow.\u003CDownloadPackage\u003Ec__AnonStorey0();
      // ISSUE: reference to a compiler-generated field
      packageCAnonStorey0.\u0024this = this;
      // ISSUE: reference to a compiler-generated field
      packageCAnonStorey0.item = this.m_Asset.previewInfo;
      this.m_Purchasing = AssetStoreInstaBuyWindow.PurchaseStatus.Downloading;
      // ISSUE: reference to a compiler-generated field
      packageCAnonStorey0.item.downloadProgress = 0.0f;
      // ISSUE: reference to a compiler-generated field
      packageCAnonStorey0.item.buildProgress = -1f;
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated method
      AssetStoreContext.Download(this.m_Asset.packageID.ToString(), packageCAnonStorey0.item.packageUrl, packageCAnonStorey0.item.encryptionKey, packageCAnonStorey0.item.packageName, packageCAnonStorey0.item.publisherName, packageCAnonStorey0.item.categoryName, new AssetStoreUtils.DownloadDoneCallback(packageCAnonStorey0.\u003C\u003Em__0));
    }

    private enum PurchaseStatus
    {
      Init,
      InProgress,
      Declined,
      Complete,
      StartBuild,
      Building,
      Downloading,
    }
  }
}
