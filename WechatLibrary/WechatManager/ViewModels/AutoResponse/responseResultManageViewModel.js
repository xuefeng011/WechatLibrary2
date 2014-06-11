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
            winModifyImageMessage: Ext.getCmp('winModifyImageMessage'),
            txtModifyImageMessageMediaId: Ext.getCmp('txtModifyImageMessageMediaId'),
            winNewNewsMessage: Ext.getCmp('winNewNewsMessage'),
            txtNewNewsMessageTitle: Ext.getCmp('txtNewNewsMessageTitle'),
            txtNewNewsMessageDescription: Ext.getCmp('txtNewNewsMessageDescription'),
            txtNewNewsMessageUrl: Ext.getCmp('txtNewNewsMessageUrl'),
            txtNewNewsMessagePicUrl: Ext.getCmp('txtNewNewsMessagePicUrl'),
            addNewTextResponseCommand: function (parameters) {
                window.viewModel.txtNewTextMessageContent.setRawValue('');
                window.viewModel.winNewTextMessage.show();
            },
            addNewImageResponseCommand: function (parameters) {
                window.viewModel.txtNewImageMessageMediaId.setRawValue('');
                window.viewModel.winNewImageMessage.show();
            },
            addNewNewsResponseCommand: function (parameters) {
                window.viewModel.txtNewNewsMessageTitle.setRawValue('');
                window.viewModel.txtNewNewsMessageDescription.setRawValue('');
                window.viewModel.txtNewNewsMessageUrl.setRawValue('');
                window.viewModel.txtNewNewsMessagePicUrl.setRawValue('');
                window.viewModel.winNewNewsMessage.show();
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
                                window.viewModel.winNewTextMessage.close();
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
                                window.viewModel.winNewImageMessage.close();
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
            submitNewNewsImageResponseCommand: function (parameters) {
                var title = window.viewModel.txtNewNewsMessageTitle.getRawValue();
                var description = window.viewModel.txtNewNewsMessageDescription.getRawValue();
                var url = window.viewModel.txtNewNewsMessageUrl.getRawValue();
                var picUrl = window.viewModel.txtNewNewsMessagePicUrl.getRawValue();
                Ext.Ajax.request({
                    url: '/Service/AutoResponseService/AddNewsResult.ashx',
                    method: 'POST',
                    params: {
                        Title: title,
                        Description: description,
                        Url: url,
                        PicUrl: picUrl
                    },
                    success: function (response, options) {
                        var responseText = response.responseText;
                        var responseObj = Ext.decode(responseText);
                        if (responseObj.success) {
                            Ext.Msg.alert('Success', responseObj.info, function () {
                                window.viewModel.storeNewsMessage.load();
                                window.viewModel.winNewNewsMessage.close();
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
                    window.viewModel.txtModifyTextMessageContent.setRawValue(data.content);
                    window.viewModel.winModifyTextMessage.editId = data.Id;
                    window.viewModel.winModifyTextMessage.show();
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
            },
            imageResponseCommandClickCommand: function (parameters) {
                var commandName = parameters[1];
                var data = parameters[2].data;

                if (commandName == "modify") {
                    window.viewModel.txtModifyImageMessageMediaId.setRawValue(data.mediaId);
                    window.viewModel.winModifyImageMessage.editId = data.Id;
                    window.viewModel.winModifyImageMessage.show();
                }
                else if (commandName == "delete") {
                    Ext.Msg.confirm('Warning', 'delete the image response?', function (btn) {
                        if (btn == "yes") {
                            Ext.Ajax.request({
                                url: '/Service/AutoResponseService/DeleteImageResult.ashx',
                                method: 'POST',
                                params: { Id: data.Id },
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
                                    Ext.Msg.alert('Error', 'delete fail!');
                                }
                            });
                        }
                    });
                }
            },
            newsResponseCommandClickCommand: function (parameters) {
                var commandName = parameters[1];
                var data = parameters[2].data;

                if (commandName == "modify") {
                    alert('modify!!!');
                } else if (commandName == "delete") {
                    Ext.Msg.confirm('Warning', 'delete this news response?', function (btn) {
                        if (btn == 'yes') {
                            Ext.Ajax.request({
                                url: '/Service/AutoResponseService/DeleteNewsResult.ashx',
                                method: 'POST',
                                params: {
                                    Id: data.Id
                                },
                                success: function (response, options) {
                                    var responseText = response.responseText;
                                    var responseObj = Ext.decode(responseText);
                                    if (responseObj.success) {
                                        Ext.Msg.alert('Success', responseObj.info, function () {
                                            window.viewModel.storeNewsMessage.load();
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
            },
            submitModifyTextResponseCommand: function (parameters) {
                var id = window.viewModel.winModifyTextMessage.editId;
                var text = window.viewModel.txtModifyTextMessageContent.getValue();
                Ext.Ajax.request({
                    url: '/Service/AutoResponseService/ModifyTextResult.ashx',
                    method: 'POST',
                    params: {
                        Id: id,
                        Content: text
                    },
                    success: function (response, options) {
                        var responseText = response.responseText;
                        var responseObj = Ext.decode(responseText);
                        if (responseObj.success) {
                            Ext.Msg.alert('Success', responseObj.info, function () {
                                window.viewModel.storeTextMessage.load();
                                window.viewModel.winModifyTextMessage.close();
                            });
                        } else {
                            Ext.Msg.alert('Error', responseObj.info);
                        }
                    },
                    failure: function (response, options) {
                        Ext.Msg.alert('Error', 'edit fail!');
                    }
                });
            },
            submitModifyImageResponseCommand: function (parameters) {
                var id = window.viewModel.winModifyImageMessage.editId;
                var mediaId = window.viewModel.txtModifyImageMessageMediaId.getValue();
                Ext.Ajax.request({
                    url: '/Service/AutoResponseService/ModifyImageResult.ashx',
                    method: 'POST',
                    params: {
                        Id: id,
                        MediaId: mediaId
                    },
                    success: function (response, options) {
                        var responseText = response.responseText;
                        var responseObj = Ext.decode(responseText);
                        if (responseObj.success) {
                            Ext.Msg.alert('Success', responseObj.info, function () {
                                window.viewModel.storeImageMessage.load();
                                window.viewModel.winModifyImageMessage.close();
                            });
                        } else {
                            Ext.Msg.alert('Error', responseObj.info);
                        }
                    },
                    failure: function (response, options) {
                        Ext.Msg.alert('Error', 'edit fail!');
                    }
                });
            }
        };
    });
}());
