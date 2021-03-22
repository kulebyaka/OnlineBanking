import React, { useEffect } from 'react'
import Head from 'next/head'
import Dashboard from '../app/pages/dashboard'

const App = () => {
  useEffect(() => {
    const jssStyles = document.querySelector('#jss-server-side')
    if (jssStyles && jssStyles.parentElement) {
      jssStyles.parentElement.removeChild(jssStyles)
    }
  }, [])

  return (
    <>
      <Head>
        <title>Int64</title>
      </Head>
      <Dashboard />
    </>
  )
}

export default App
