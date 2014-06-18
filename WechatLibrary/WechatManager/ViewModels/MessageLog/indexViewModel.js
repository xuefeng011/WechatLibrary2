(function () {
    "use strict";
    Ext.onReady(function () {
        window.viewModel = window.viewModel || {
            showMessageDetailCommand: function (parameters) {
                var data = parameters[3].data;

                var pnlRequestMessage = window.viewModel.pnlRequestMessage;
                var loaderRequestMessage = pnlRequestMessage.loader;
                loaderRequestMessage.suspendEvents();
                loaderRequestMessage.url = "/Service/MessageLogService/GetRequestMessageSource.ashx?Id=" + data.RequestId;
                pnlRequestMessage.load();

                var pnlResponseResult = window.viewModel.pnlResponseResult;
                var loaderResponseResult = pnlResponseResult.loader;
                loaderResponseResult.suspendEvents();
                loaderResponseResult.url = "/Service/MessageLogService/GetResponseResultSource.ashx?Id=" + data.RequestId;
                pnlResponseResult.load();

                window.viewModel.winMessageDetail.show();
            },
            winMessageDetail: Ext.getCmp('winMessageDetail'),
            pnlRequestMessage: Ext.getCmp('pnlRequestMessage'),
            pnlResponseResult: Ext.getCmp('pnlResponseResult')
        };
    });
}());
