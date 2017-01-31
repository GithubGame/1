import React, { Component } from 'react';
import ChatInput from './ChatInput';
import ChatContent from './ChatContent';
import LoginInput from './LoginInput';
import RemoteUserDisplay from './RemoteUserDisplay';
import LocalUserDisplay from './LocalUserDisplay';
import Header from './Header';
import '../node_modules/bootstrap/dist/css/bootstrap.css';
import './App.css';

class App extends Component {
  constructor(props) {
    super(props);

    this.state = {
      loggedIn: false,
      username: '',
      messages: [
        { user: 'Marco', message: 'Hola', timestamp: new Date() },
        { user: 'Marco', message: 'Whoops! I mean, hello! :smiley:', timestamp: new Date() },
        { user: 'Marco', message: 'My name is Marco and I am learning to speak english.', timestamp: new Date() },
        { user: 'Marco', message: 'I notice you\'re trying to learn spanish, why don\'t you say hello in spanish?', timestamp: new Date() },
        { user: 'Marco', message: 'Hint, I\'ve already said it once by accident', timestamp: new Date() },
      ],
      usersConnected: {
        client: {
          userName: 'Zac Braddy',
          learning: 'Spanish',
          canSpeak: 'English'
        },
        remote: {
          userName: 'Marco',
          learning: 'English',
          canSpeak: 'Spanish'
        }
      }
    };

    this.addMessage = this.addMessage.bind(this);
    this.setLogedIn = this.setLogedIn.bind(this);
  }
  setLogedIn(user) {
    this.setState({
      loggedIn: true
    });
    console.log(user);
  }
  addMessage(message, user, timestamp) {
    const messages = this.state.messages;

    messages.push({
      user,
      message,
      timestamp
    });

    if (message.toLowerCase().indexOf('hola') > -1) {
      messages.push({
        user: 'Marco',
        message: 'YES! Well done, think of all the fun we\'re going to have learning a language together!',
        timestamp: new Date()
      });
    } else {
      messages.push({
        user: 'Marco',
        message: 'Close but no cigar, try "Hola"',
        timestamp: new Date()
      });
    }

    this.setState(
      {
        messages
      }
    )
  }

  render() {
    if (this.state.loggedIn) {
      return (
        <div className="panel panel-default content">
          <div className="panel-body content-body">
            <div className="row">
              <Header />
            </div>
            <div className="row interface-row">
              <div className="col-lg-2 interface-user-display">
                <div className="row your-talking-to-display">
                  <RemoteUserDisplay userInfo={this.state.usersConnected.remote} />
                </div>
                <div className="row you-display">
                  <LocalUserDisplay userInfo={this.state.usersConnected.client} />
                </div>
              </div>
              <div className="col-lg-2 chat-content-row">
                <ChatContent addMessage={this.addMessage} messages={this.state.messages} />
              </div>
            </div>
            <div className="row chat-input-row">
              <ChatInput addMessage={this.addMessage} />
            </div>
          </div>
        </div>
      );
    } else {
      return (
        <LoginInput setLogedIn={this.setLogedIn} />
      );
    }
  }
}

export default App;
