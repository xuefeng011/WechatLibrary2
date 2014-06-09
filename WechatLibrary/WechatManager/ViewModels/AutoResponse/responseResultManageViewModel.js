(function () {
    "use strict";
    Ext.onReady(function () {
        window.viewModel = window.viewModel || {
            storeTextMessage: Ext.StoreManager.get('storeTextMessage'),
            storeImageMessage: Ext.StoreManager.get('storeImageMessage'),
            storeNewsMessage: Ext.StoreManager.get('storeNewsMessage'),
            winNewTextMessage: Ext.getCmp('winNewTextMessage'),
            txtNewTextMessageContent: Ext.getCmp('txtNewTextMessageContent'),
            winModifyTextMessage: Ext.getCmp('winModifyTextMessage'),
            txtModifyTextMessageContent: Ext.getCmp('txtModifyTextMessageContent'),
            addNewTextResponseCommand: function (parameters) {
                window.viewModel.txtNewTextMessageContent.setRawValue('');
                window.viewModel.winNewTextMessage.show();
            },
            submitNewTextResponseCommand: function (parameters) {
                Ext.Ajax.request({
                    url: '/Service/AutoResponseService/AddTextResult.ashx',
                    method: 'POST',
                    params: {
                        Content:window.viewModel.txtNewTextMessageContent.getValue()
                    },
                    success: function (response, options) {
                        var responseText = response.responseText;
                        var responseObj = Ext.decode(responseText);
                        if (responseObj.success) {
                            Ext.Msg.alert('Success', responseObj.info, function () {
                                window.viewModel.storeTextMessage.load();
                            });
                        } else {
                            Ext.Msg.alert('Error',responseObj.info);
                        }
                    },
                    failure: function (response, options) {
                        Ext.Msg.alert('Error','add fail!');
                    }
                });
            },
            textResponseCommandClickCommand: function (parameters) {
                var commandName = parameters[1];
                var data = parameters[2].data;

                if (commandName == "modify") {
                } else if (commandName == "delete") {
                    Ext.Msg.confirm('Warning', 'delete this text response?', function (btn) {
                        if (btn == "yes") {
                            Ext.Ajax.request({
                                url: 'Service/AutoResponseService/DeleteTextResult.ashx',
                                method: 'POST',
                                params: {
                                    Id: data.Id
                                },
                                success: function (response, options) {
                                    var responseText = response.responseText;
                                    var responseObj = Ext.decode(responseText);
                                    if (responseObj.success) {
                                        Ext.Msg.alert('Success', responseObj.info, function () {
                                            window.viewModel.storeTextMessage.load();
                                        });
                                    } else {
                                        Ext.Msg.alert('Error', responseObj.info);
                                    }
                                },
                                failure: function (response, options) {
                                    Ext.Msg.alert('Error', 'delete fail!');
                                }
                            });
                        }
                    });
                }
            }
        };
    });
}());
