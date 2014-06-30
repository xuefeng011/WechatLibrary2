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
            pnlResponseResult: Ext.getCmp('pnlResponseResult'),
            winSendCustomerServiceMessage: Ext.getCmp('winSendCustomerServiceMessage'),
            cmbResponseTextMessage: Ext.getCmp('cmbResponseTextMessage'),
            cmbResponseImageMessage: Ext.getCmp('cmbResponseImageMessage'),
            cmbResponseVoiceMessage: Ext.getCmp('cmbResponseVoiceMessage'),
            cmbResponseNewsMessage: Ext.getCmp('cmbResponseNewsMessage'),
            sendCommandClickCommand: function (parameters) {
                var commandName = parameters[1];
                var data = parameters[2].data;

                if (commandName == 'send') {
                    var requestLogTime = data.RequestLogTime;

                    var checkTimeIsExpires = function (str) {
                        str = str.replace('年', '-').replace('月', '-').replace('日', 'T').replace('时', ':').replace('分', ':').replace('秒', '');
                        var date = new Date(str);
                        var now = new Date();
                        if (now - date > 1000 * 60 * 60 * 48) {
                            return true;// 超过 48 小时，不能回复。
                        } else {
                            return false;
                        }
                    };

                    if (checkTimeIsExpires(requestLogTime) === true) {
                        Ext.Msg.alert('Error', '该消息超过 48 小时，无法回复！');
                        return;
                    }

                    window.viewModel.cmbResponseTextMessage.hide();
                    window.viewModel.pnlResponseTextMessage.hide();
                    window.viewModel.cmbResponseImageMessage.hide();
                    window.viewModel.pnlResponseImageMessage.hide();
                    window.viewModel.cmbResponseVoiceMessage.hide();
                    window.viewModel.pnlResponseVoiceMessage.hide();
                    window.viewModel.cmbResponseNewsMessage.hide();
                    window.viewModel.cmbResponseType.setValue('');

                    // Cache user openid.
                    window.viewModel.winSendCustomerServiceMessage.toUserName = data.FromUserName;
                    window.viewModel.winSendCustomerServiceMessage.show();
                }
            },
            cmbResponseType: Ext.getCmp('cmbResponseType'),
            cmbResponseTypeSelected: function (parameters) {
                var selectedValue = window.viewModel.cmbResponseType.value;
                if (selectedValue == '文本') {
                    // Set combobox visible.
                    window.viewModel.cmbResponseTextMessage.show();
                    window.viewModel.cmbResponseImageMessage.hide();
                    window.viewModel.cmbResponseVoiceMessage.hide();
                    window.viewModel.cmbResponseNewsMessage.hide();
                    // Set panel visible.
                    window.viewModel.pnlResponseTextMessage.show();
                    window.viewModel.pnlResponseImageMessage.hide();
                    window.viewModel.pnlResponseVoiceMessage.hide();
                    // Load Text Message From Data Base.
                    Ext.Ajax.request({
                        url: '/Service/MessageLogService/LoadTextResults.ashx',
                        method: 'POST',
                        success: function (response, options) {
                            var responseText = response.responseText;
                            var responseObj = Ext.decode(responseText);
                            if (responseObj.success) {
                                var data = responseObj.data;
                                /* Remove the combobox old datas.*/
                                while (window.viewModel.cmbResponseTextMessage.store.getCount() > 0) {
                                    window.viewModel.cmbResponseTextMessage.removeByIndex(0);
                                }
                                for (var i = 0; i < data.length; i++) {
                                    /* The first parameter is the display field and the second parameter is the value field. */
                                    window.viewModel.cmbResponseTextMessage.addItem(data[i].Content, data[i].Id);
                                }
                                window.viewModel.chkResponseTextMessage.setValue(false);
                                window.viewModel.txtResponseTextMessage.setValue('');
                            } else {
                                Ext.Msg.alert('Error', responseObj.info);
                            }
                        },
                        failure: function (response, options) {
                            Ext.Msg.alert('Error', 'load text resources fail!');
                        }
                    });
                } else if (selectedValue == '图片') {
                    // Set combobox visible.
                    window.viewModel.cmbResponseTextMessage.hide();
                    window.viewModel.cmbResponseImageMessage.show();
                    window.viewModel.cmbResponseVoiceMessage.hide();
                    window.viewModel.cmbResponseNewsMessage.hide();
                    // Set panel visible.
                    window.viewModel.pnlResponseTextMessage.hide();
                    window.viewModel.pnlResponseImageMessage.show();
                    window.viewModel.pnlResponseVoiceMessage.hide();
                    // Load Image Messages From Data Base.
                    Ext.Ajax.request({
                        url: '/Service/MessageLogService/LoadImageResults.ashx',
                        method: 'POST',
                        success: function (response, options) {
                            var responseText = response.responseText;
                            var responseObj = Ext.decode(responseText);
                            if (responseObj.success) {
                                var data = responseObj.data;
                                /* Remove the combobox old datas.*/
                                while (window.viewModel.cmbResponseImageMessage.store.getCount() > 0) {
                                    window.viewModel.cmbResponseImageMessage.removeByIndex(0);
                                }
                                for (var i = 0; i < data.length; i++) {
                                    /* The first parameter is the display field and the second parameter is the value field. */
                                    window.viewModel.cmbResponseImageMessage.addItem(data[i].ImgName, data[i].Id);
                                }
                                window.viewModel.chkResponseImageMessage.setValue(false);
                                window.viewModel.fileResponseImageMessage.reset();
                            } else {
                                Ext.Msg.alert('Error', responseObj.info);
                            }
                        },
                        failure: function (response, options) {
                            Ext.Msg.alert('Error', 'Load image resources fail!');
                        }
                    });
                } else if (selectedValue == '语音') {
                    // Set combobox visible.
                    window.viewModel.cmbResponseTextMessage.hide();
                    window.viewModel.cmbResponseImageMessage.hide();
                    window.viewModel.cmbResponseVoiceMessage.show();
                    window.viewModel.cmbResponseNewsMessage.hide();
                    // Set panel visible.
                    window.viewModel.pnlResponseTextMessage.hide();
                    window.viewModel.pnlResponseImageMessage.hide();
                    window.viewModel.pnlResponseVoiceMessage.show();
                    // Load Voice Message From Data Base.
                    Ext.Ajax.request({
                        url: '/Service/MessageLogService/LoadVoiceResults.ashx',
                        method: 'POST',
                        success: function (response, options) {
                            var responseText = response.responseText;
                            var responseObj = Ext.decode(responseText);
                            if (responseObj.success) {
                                var data = responseObj.data;
                                /* Remove the combobox old datas. */
                                while (window.viewModel.cmbResponseVoiceMessage.store.getCount() > 0) {
                                    window.viewModel.cmbResponseVoiceMessage.removeByIndex(0);
                                }
                                for (var i = 0; i < data.length; i++) {
                                    /* The first parameter is the display field and the second parameter is the value field. */
                                    window.viewModel.cmbResponseVoiceMessage.addItem(data[i].VoiceName, data[i].Id);
                                }
                                window.viewModel.chkResponseVoiceMessage.setValue(false);
                                window.viewModel.fileResponseVoiceMessage.reset();
                            } else {
                                Ext.Msg.alert('Error', responseObj.info);
                            }
                        },
                        failure: function (response, options) {
                            Ext.Msg.alert('Error', 'Load voice resources fail!');
                        }
                    });
                } else if (selectedValue == '图文') {
                    // Set combobox visible.
                    window.viewModel.cmbResponseTextMessage.hide();
                    window.viewModel.cmbResponseImageMessage.hide();
                    window.viewModel.cmbResponseVoiceMessage.hide();
                    window.viewModel.cmbResponseNewsMessage.show();
                    // Set panel visible.
                    window.viewModel.pnlResponseTextMessage.hide();
                    window.viewModel.pnlResponseImageMessage.hide();
                    window.viewModel.pnlResponseVoiceMessage.hide();
                    // Load News Message From Data Base.
                    Ext.Ajax.request({
                        url: '/Service/MessageLogService/LoadNewsResults.ashx',
                        method: 'POST',
                        success: function (response, options) {
                            var responseText = response.responseText;
                            var responseObj = Ext.decode(responseText);
                            if (responseObj.success) {
                                var data = responseObj.data;
                                /* Remove the combobox old datas. */
                                while (window.viewModel.cmbResponseNewsMessage.store.getCount() > 0) {
                                    window.viewModel.cmbResponseNewsMessage.removeByIndex(0);
                                }
                                for (var i = 0; i < data.length; i++) {
                                    /* The first parameter is the display field and the second parameter is the value field. */
                                    window.viewModel.cmbResponseNewsMessage.addItem(data[i].Title, data[i].Id);
                                }
                            } else {
                                Ext.Msg.alert('Error', responseObj.info);
                            }
                        },
                        failure: function (response, options) {
                            Ext.Msg.alert('Error', 'Load news resources fail!');
                        }
                    });
                }
            },
            sendCustomerMessageCommand: function (parameters) {
                var responseType = window.viewModel.cmbResponseType.value;
                if (responseType == '' || responseType == null) {
                    Ext.Msg.alert('Error', 'please select a type to response!');
                    return;
                }

                var id = '';
                if (responseType == '文本') {
                    responseType = "text";
                    id = window.viewModel.cmbResponseTextMessage.value;
                }
                if (responseType == '图片') {
                    responseType = "image";
                    id = window.viewModel.cmbResponseImageMessage.value;
                }
                if (responseType == '语音') {
                    responseType = "voice";
                    id = window.viewModel.cmbResponseVoiceMessage.value;
                }
                if (responseType == '图文') {
                    responseType = 'news';
                    id = window.viewModel.cmbResponseNewsMessage.value;
                }

                if (id == '') {
                    Ext.Msg.alert('please select an item to response!');
                    return;
                }

                if (responseType == 'text' && window.viewModel.chkResponseTextMessage.checked) {
                    Ext.Ajax.request({
                        url: '/Service/MessageLogService/SendTextCustom.ashx',
                        method: 'POST',
                        params: {
                            ToUserName: window.viewModel.winSendCustomerServiceMessage.toUserName,
                            Content: window.viewModel.txtResponseTextMessage.getValue()
                        },
                        success: function (response, options) {
                            var responseText = response.responseText;
                            var responseObj = Ext.decode(responseText);
                            if (responseObj.success) {
                                Ext.Msg.alert('Success', responseObj.info, function () {
                                    window.viewModel.winSendCustomerServiceMessage.close();
                                });
                            } else {
                                Ext.Msg.alert('Error', responseObj.info);
                            }
                        },
                        failure: function (response, options) {
                            Ext.Msg.alert('Error', 'send fail!');
                        }
                    });
                    return;
                }

                if (responseType == 'image' && window.viewModel.chkResponseImageMessage.checked) {
                    window.viewModel.formResponseImageMessage.getForm().submit({
                        url: '/Service/MessageLogService/SendImageCustom.ashx?ToUserName=' + window.viewModel.winSendCustomerServiceMessage.toUserName,
                        success: function (form, action) {
                            var responseObj = action.result;
                            if (responseObj.success) {
                                Ext.Msg.alert('Success', responseObj.info, function () {
                                    window.viewModel.winSendCustomerServiceMessage.close();
                                });
                            } else {
                                Ext.Msg.alert('Error', responseObj.info);
                            }
                        },
                        failure: function (form, action) {
                            var responseObj = action.result;
                            if (responseObj.success) {
                                Ext.Msg.alert('Success', responseObj.info, function () {
                                    window.viewModel.winSendCustomerServiceMessage.close();
                                });
                            } else {
                                Ext.Msg.alert('Error', responseObj.info);
                            }
                        }
                    });
                    return;
                }

                if (responseType == 'voice' && window.viewModel.chkResponseVoiceMessage.checked) {
                    window.viewModel.formResponseVoiceMessage.getForm().submit({
                        url: '/Service/MessageLogService/SendVoiceCustom.ashx?ToUserName=' + window.viewModel.winSendCustomerServiceMessage.toUserName,
                        success: function (form, action) {
                            var responseObj = action.result;
                            if (responseObj.success) {
                                Ext.Msg.alert("Success", responseObj.info, function () {
                                    window.viewModel.winSendCustomerServiceMessage.close();
                                });
                            } else {
                                Ext.Msg.alert('Error', responseObj.info);
                            }
                        },
                        failure: function (form, action) {
                            var responseObj = action.result;
                            if (responseObj.success) {
                                Ext.Msg.alert('Success', responseObj.info, function () {
                                    window.viewModel.winSendCustomerServiceMessage.close();
                                });
                            } else {
                                Ext.Msg.alert('Error', responseObj.info);
                            }
                        }
                    });
                }

                Ext.Ajax.request({
                    url: '/Service/MessageLogService/Send.ashx',
                    method: 'POST',
                    params: {
                        Type: responseType,
                        Id: id,
                        ToUserName: window.viewModel.winSendCustomerServiceMessage.toUserName
                    },
                    success: function (response, options) {
                        var responseText = response.responseText;
                        var responseObj = Ext.decode(responseText);
                        if (responseObj.success) {
                            Ext.Msg.alert('Success', responseObj.info, function () {
                                window.viewModel.winSendCustomerServiceMessage.close();
                            });
                        } else {
                            Ext.Msg.alert('Error', responseObj.info);
                        }
                    },
                    failure: function (response, options) {
                        Ext.Msg.alert('Error', 'send fail!');
                    }
                });
            },
            pnlResponseTextMessage: Ext.getCmp('pnlResponseTextMessage'),
            chkResponseTextMessage: Ext.getCmp('chkResponseTextMessage'),
            txtResponseTextMessage: Ext.getCmp('txtResponseTextMessage'),
            pnlResponseImageMessage: Ext.getCmp('pnlResponseImageMessage'),
            formResponseImageMessage: Ext.getCmp('formResponseImageMessage'),
            chkResponseImageMessage: Ext.getCmp('chkResponseImageMessage'),
            fileResponseImageMessage: Ext
.getCmp('fileResponseImageMessage'),
            pnlResponseVoiceMessage: Ext.getCmp('pnlResponseVoiceMessage'),
            formResponseVoiceMessage: Ext.getCmp('formResponseVoiceMessage'),
            chkResponseVoiceMessage: Ext.getCmp('chkResponseVoiceMessage'),
            fileResponseVoiceMessage: Ext.getCmp('fileResponseVoiceMessage')
        };
    });
}());
