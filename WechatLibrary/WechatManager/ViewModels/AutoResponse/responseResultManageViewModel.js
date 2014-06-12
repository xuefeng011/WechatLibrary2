(function () {
    "use strict";
    Ext.onReady(function () {
        window.viewModel = window.viewModel || {
            storeTextMessage: Ext.StoreManager.get('storeTextMessage'),
            storeImageMessage: Ext.StoreManager.get('storeImageMessage'),
            storeNewsMessage: Ext.StoreManager.get('storeNewsMessage'),
            storeNewsArticles: Ext.StoreManager.get('storeNewsArticles'),
            winModifyNewsArticle: Ext.getCmp('winModifyNewsArticle'),
            txtModifyNewsArticleTitle: Ext.getCmp('txtModifyNewsArticleTitle'),
            txtModifyNewsArticleDescription: Ext.getCmp('txtModifyNewsArticleDescription'),
            txtModifyNewsArticleUrl: Ext.getCmp('txtModifyNewsArticleUrl'),
            txtModifyNewsArticlePicUrl: Ext.getCmp('txtModifyNewsArticlePicUrl'),
            winAddNewNewsArticle: Ext.getCmp('winAddNewNewsArticle'),
            txtNewNewsArticleTitle: Ext.getCmp('txtNewNewsArticleTitle'),
            txtNewNewsArticleDescription: Ext.getCmp('txtNewNewsArticleDescription'),
            txtNewNewsArticleUrl: Ext.getCmp('txtNewNewsArticleUrl'),
            txtNewNewsArticlePicUrl: Ext.getCmp('txtNewNewsArticlePicUrl'),
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
            winModifyNewsMessage: Ext.getCmp('winModifyNewsMessage'),
            txtModifyNewsMessageTitle: Ext.getCmp('txtModifyNewsMessageTitle'),
            txtModifyNewsMessageDescription: Ext.getCmp('txtModifyNewsMessageDescription'),
            txtModifyNewsMessageUrl: Ext.getCmp('txtModifyNewsMessageUrl'),
            txtModifyNewsMessagePicUrl: Ext.getCmp('txtModifyNewsMessagePicUrl'),
            submitModifyNewsArticleChange: function (parameters) {
                var id = window.viewModel.winModifyNewsArticle.ArticleId;
                var title = window.viewModel.txtModifyNewsArticleTitle.getValue();
                var description = window.viewModel.txtModifyNewsArticleDescription.getValue();
                var url = window.viewModel.txtModifyNewsArticleUrl.getValue();
                var picUrl = window.viewModel.txtModifyNewsArticlePicUrl.getValue();

                Ext.Ajax.request({
                    url: '/Service/AutoResponseService/ModifyNewsArticle.ashx',
                    method: 'POST',
                    params: {
                        Id: id,
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

                                // Refresh the grid.
                                window.viewModel.storeNewsArticles.load();
                                window.viewModel.winModifyNewsArticle.close();
                            });
                        } else {
                            Ext.Msg.alert('Error', responseObj.info);
                        }
                    },
                    failure: function (response, options) {
                        Ext.Msg.alert('Error', 'modify fail!');
                    }
                });
            },
            gridNewsArticleCommandClickCommand: function (parameters) {
                var commandName = parameters[1];
                var data = parameters[2].data;

                if (commandName == 'modify') {
                    var modifyId = data.Id;
                    window.viewModel.winModifyNewsArticle.ArticleId = modifyId;
                    window.viewModel.txtModifyNewsArticleTitle.setRawValue(data.Title);
                    window.viewModel.txtModifyNewsArticleDescription.setRawValue(data.Description);
                    window.viewModel.txtModifyNewsArticleUrl.setRawValue(data.Url);
                    window.viewModel.txtModifyNewsArticlePicUrl.setRawValue(data.PicUrl);
                    window.viewModel.winModifyNewsArticle.show();
                } else if (commandName == 'delete') {
                    var deleteId = data.Id;
                    Ext.Ajax.request({
                        url: '/Service/AutoResponseService/DeleteNewsArticle.ashx',
                        method: 'POST',
                        params: {
                            Id: deleteId
                        },
                        success: function (response, options) {
                            var responseText = response.responseText;
                            var responseObj = Ext.decode(responseText);
                            if (responseObj.success) {
                                Ext.Msg.alert('Success', responseObj.info, function () {


                                    // Refresh the count.
                                    window.viewModel.storeNewsMessage.load();
                                    // Refresh the grid.
                                    window.viewModel.storeNewsArticles.load();
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
            },
            submitNewNewsArticle: function (parameters) {
                var messageId = window.viewModel.winAddNewNewsArticle.MessageId;
                var title = window.viewModel.txtNewNewsArticleTitle.getValue();
                var description = window.viewModel.txtNewNewsArticleDescription.getValue();
                var url = window.viewModel.txtNewNewsArticleUrl.getValue();
                var picUrl = window.viewModel.txtNewNewsArticlePicUrl.getValue();
                Ext.Ajax.request({
                    url: '/Service/AutoResponseService/AddNewsArticle.ashx',
                    method: 'POST',
                    params: { MessageId: messageId, Title: title, Description: description, Url: url, PicUrl: picUrl },
                    success: function (response, options) {
                        var responseText = response.responseText;
                        var responseObj = Ext.decode(responseText);
                        if (responseObj.success) {
                            Ext.Msg.alert('Success', responseObj.info, function () {

                                // Refresh the count.
                                window.viewModel.storeNewsMessage.load();

                                // Refresh the grid.
                                window.viewModel.storeNewsArticles.load();
                                window.viewModel.winAddNewNewsArticle.close();
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
                    var modifyId = data.Id;
                    Ext.Ajax.request({
                        url: '/Service/AutoResponseService/GetNewsResultById.ashx',
                        method: 'POST',
                        params: {
                            Id: modifyId
                        },
                        success: function (response, options) {
                            var responseText = response.responseText;
                            var responseObj = Ext.decode(responseText);
                            if (responseObj.success) {
                                var data = responseObj.data;
                                window.viewModel.txtModifyNewsMessageTitle.setRawValue(data.Title);
                                window.viewModel.txtModifyNewsMessageDescription.setRawValue(data.Description);
                                window.viewModel.txtModifyNewsMessageUrl.setRawValue(data.Url);
                                window.viewModel.txtModifyNewsMessagePicUrl.setRawValue(data.PicUrl);
                                // Refresh the 2-10 news article grid.
                                window.viewModel.storeNewsArticles.proxy.url = "/Service/AutoResponseService/GetNewsArticles.ashx" + "?Id=" + data.MessageId;
                                window.viewModel.storeNewsArticles.load();

                                // Cache the modify messsage id.
                                window.viewModel.winModifyNewsMessage.MessageId = data.MessageId;

                                // Cache the modify article id.
                                window.viewModel.winModifyNewsMessage.ArticleId = data.ArticleId;

                                // Show the setting window.
                                window.viewModel.winModifyNewsMessage.show();
                            } else {
                                Ext.Msg.alert('Error', responseObj.info);
                            }
                        },
                        failure: function (response, options) {
                            Ext.Msg.alert('Error', 'load information fail!');
                        }
                    });
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
            addNewNewsArticle: function (parameters) {
                // Get message id from window.
                var messageId = window.viewModel.winModifyNewsMessage.MessageId;

                // Cache message id to the setting window.
                window.viewModel.winAddNewNewsArticle.MessageId = messageId;

                // clear control value.
                window.viewModel.txtNewNewsArticleTitle.setRawValue('');
                window.viewModel.txtNewNewsArticleDescription.setRawValue('');
                window.viewModel.txtNewNewsArticleUrl.setRawValue('');
                window.viewModel.txtNewNewsArticlePicUrl.setRawValue('');
                window.viewModel.winAddNewNewsArticle.show();
            },
            submitNewsMessageChange: function (parameters) {
                var modifyArticleId = window.viewModel.winModifyNewsMessage.ArticleId;
                var title = window.viewModel.txtModifyNewsMessageTitle.getValue();
                var description = window.viewModel.txtModifyNewsMessageDescription.getValue();
                var url = window.viewModel.txtModifyNewsMessageUrl.getValue();
                var picUrl = window.viewModel.txtModifyNewsMessagePicUrl.getValue();

                Ext.Ajax.request({
                    url: '/Service/AutoResponseService/ModifyNewsArticle.ashx',
                    method: 'POST',
                    params: {
                        Id: modifyArticleId,
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
                            });
                        } else {
                            Ext.Msg.alert('Error', responseObj.info);
                        }
                    },
                    failure: function (response, options) {
                        Ext.Msg.alert('Error', 'Modify the news article fail!');
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
