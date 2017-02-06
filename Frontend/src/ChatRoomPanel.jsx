import React, { Component } from 'react';
import ChatInput from './ChatInput';
import ChatContent from './ChatContent';
import RemoteUserDisplay from './RemoteUserDisplay';
import LocalUserDisplay from './LocalUserDisplay';
import Header from './Header';



class ChatRoomPanel extends Component {
  constructor(props) {
    super(props);

    this.state = {
      messages: [ ],
    };

    this.addMessage = this.addMessage.bind(this);
  }

  addMessage(message, user, timestamp) {
    const messages = this.state.messages;

    messages.push({
      user,
      message,
      timestamp
    });

    this.setState(
      {
        messages
      }
    )
  }

  render() {
      return (
        <div className="panel panel-default content">
          <div className="panel-body content-body">
            <div className="row">
              <Header />
            </div>
            <div className="row interface-row">
              <div className="col-lg-2 interface-user-display">
                <div className="row your-talking-to-display">
                  <RemoteUserDisplay userInfo={this.props.usersConnected.remote} />
                </div>
                <div className="row you-display">
                  <LocalUserDisplay userInfo={this.props.usersConnected.client} />
                </div>
              </div>
              <div className="col-lg-2 chat-content-row">
                <ChatContent addMessage={this.addMessage} messages={this.state.messages} />
              </div>
            </div>
            <div className="row chat-input-row">
              <ChatInput addMessage={this.addMessage} client={this.props.usersConnected.client.userName}/>
            </div>
          </div>
        </div>
      );    
  }
}

export default ChatRoomPanel;
