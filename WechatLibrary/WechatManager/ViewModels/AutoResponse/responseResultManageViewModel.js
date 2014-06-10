(function () {
    "use strict";
    Ext.onReady(function () {
        window.viewModel = window.viewModel || {
            storeTextMessage: Ext.StoreManager.get('storeTextMessage'),
            storeImageMessage: Ext.StoreManager.get('storeImageMessage'),
            storeNewsMessage: Ext.StoreManager.get('storeNewsMessage'),
            winNewTextMessage: Ext.getCmp('winNewTextMessage'),
            txtNewTextMessageContent: Ext.getCmp('txtNewTextMessageContent'),
            winNewImageMessage: Ext.getCmp('winNewImageMessage'),
            txtNewImageMessageMediaId: Ext.getCmp('txtNewImageMessageMediaId'),
            winModifyTextMessage: Ext.getCmp('winModifyTextMessage'),
            txtModifyTextMessageContent: Ext.getCmp('txtModifyTextMessageContent'),
            addNewTextResponseCommand: function (parameters) {
                window.viewModel.txtNewTextMessageContent.setRawValue('');
                window.viewModel.winNewTextMessage.show();
            },
            addNewImageResponseCommand: function (parameters) {
                window.viewModel.txtNewImageMessageMediaId.setRawValue('');
                window.viewModel.winNewImageMessage.show();
            },
            submitNewTextResponseCommand: function (parameters) {
                var content = window.viewModel.txtNewTextMessageContent.getValue();
                if (content == "") {
                    Ext.Msg.alert('Error', 'please input content');
                    return;
                }
                Ext.Ajax.request({
                    url: '/Service/AutoResponseService/AddTextResult.ashx',
                    method: 'POST',
                    params: {
                        Content: content
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
                        Ext.Msg.alert('Error', 'add fail!');
                    }
                });
            },
            submitNewImageResponseCommand: function (parameters) {
                var mediaId = window.viewModel.txtNewImageMessageMediaId.getValue();
                if (mediaId == "") {
                    Ext.Msg.alert('Error', 'please input mediaId');
                    return;
                }
                Ext.Ajax.request({
                    url: '/Service/AutoResponseService/AddImageResult.ashx',
                    method: 'POST',
                    params: {
                        MediaId: mediaId
                    },
                    success: function (response, options) {
                        var responseText = response.responseText;
                        var responseObj = Ext.decode(responseText);
                        if (responseObj.success) {
                            Ext.Msg.alert('Success', responseObj.info, function () {
                                window.viewModel.storeImageMessage.load();
                            });
                        } else {
                            Ext.Msg.alert('Error', responseObj.info);
                        }
                    },
                    failure: function (response, options) {
                        Ext.Msg.alert('Error', 'add fail!');
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
                                url: '/Service/AutoResponseService/DeleteTextResult.ashx',
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
