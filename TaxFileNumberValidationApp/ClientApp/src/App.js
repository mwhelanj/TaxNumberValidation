import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Info } from './components/Info';
import { ValidateTaxNo } from './components/ValidateTaxNo';

import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
            <Route exact path='/' component={ValidateTaxNo} />
        <Route path='/Info' component={Info} />
      </Layout>
    );
  }
}
