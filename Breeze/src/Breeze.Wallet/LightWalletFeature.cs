﻿using Stratis.Bitcoin.Builder.Feature;
using Microsoft.Extensions.DependencyInjection;
using Stratis.Bitcoin.Builder;
using Stratis.Bitcoin.Wallet;
using Stratis.Bitcoin.Wallet.Controllers;

namespace Breeze.Wallet
{
    public class LightWalletFeature : FullNodeFeature
    {
        private readonly IWalletSyncManager walletSyncManager;

        public LightWalletFeature(IWalletSyncManager walletSyncManager)
        {
            this.walletSyncManager = walletSyncManager;
        }

        public override void Start()
        {
            this.walletSyncManager.Initialize();
        }

        public override void Stop()
        {
            base.Stop();
        }
    }

    public static class LightWalletFeatureExtension
    {
        public static IFullNodeBuilder UseLightWallet(this IFullNodeBuilder fullNodeBuilder)
        {
            fullNodeBuilder.ConfigureFeature(features =>
            {
                features
                .AddFeature<LightWalletFeature>()
                .FeatureServices(services =>
                    {
                        services.AddSingleton<IWalletSyncManager, LightWalletSyncManager>();
                        services.AddSingleton<IWalletManager, WalletManager>();
                        services.AddSingleton<WalletController>();

                    });
            });

            return fullNodeBuilder;
        }
    }
}
