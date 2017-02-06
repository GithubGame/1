import React, { Component } from 'react';
import LoginInput from './LoginInput';
import ChatRoomPanel from './ChatRoomPanel';
import '../node_modules/bootstrap/dist/css/bootstrap.css';
import './App.css';

class App extends Component {
  constructor(props) {
    super(props);

    this.state = {
      loggedIn: false,
      username: '',
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

    this.setLogedIn = this.setLogedIn.bind(this);
  }
  setLogedIn(user) {
    const usersConnected = this.state.usersConnected;

    usersConnected.client.userName = user;

    this.setState({
      loggedIn: true,
    });
    this.setState({
      usersConnected
    });

    console.log(user);
  }
  
  render() {
    if (this.state.loggedIn) {
      return (
        <ChatRoomPanel usersConnected={this.state.usersConnected} />
      );
    } else {
      return (
        <LoginInput setLogedIn={this.setLogedIn} />
      );
    }
  }
}

export default App;
