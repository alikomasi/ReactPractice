import logo from './logo.svg';
import './App.css';
import {Component} from 'react';
import axios from 'axios';

class App extends Component {
  state={
    values:[]
  }
  componentDidMount(){
    axios.get('http://localhost:5000/api/values').then((response)=>{
  
      this.setState({
        values:response.data
         }) 
    })
  
  }
  render(){
 
    return (
      <div className="App">
        <header className="App-header">
          <img src={logo} className="App-logo" alt="logo" />
          <ul>
            {this.state.values.map((value)=>(
              <li key={value.id}>{value.name}</li>
            ))}
          </ul>
        </header>
      </div>
    );
  }
 
}

export default App;
