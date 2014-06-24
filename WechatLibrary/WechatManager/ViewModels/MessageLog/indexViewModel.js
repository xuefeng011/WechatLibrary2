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
                    window.viewModel.cmbResponseTextMessage.hide();
                    window.viewModel.cmbResponseImageMessage.hide();
                    window.viewModel.cmbResponseVoiceMessage.hide();
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

                        } else {
                            Ext.Msg.alert('Error', responseObj.info);
                        }
                    },
                    failure: function (response, options) {
                        Ext.Msg.alert('Error', 'send fail!');
                    }
                });
            }
        };
    });
}());
