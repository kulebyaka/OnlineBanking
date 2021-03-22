import React, { useEffect, useRef, useState } from 'react'
import { Layout, MapContainer } from './style'
import mapboxgl from 'mapbox-gl'
import { testData } from './data'
import Filter, { FormValues } from '../../components/filter'
import {
  getAverageAge,
  getAverageBill,
  getCreditWorthiness,
  getJSON,
} from '../../api'
import { FeatureCollection } from 'geojson'

mapboxgl.accessToken =
  'pk.eyJ1IjoiZ3JlYXRiYXNpbCIsImEiOiJja2d4b2syZW4wYTRsMnlwZHB3NDF1YXo4In0.SN2W0xPdmHU77zbxHODGow'

const Dashboard = () => {
  // const [transactions, setTransactions] = useState<Transaction[]>([])
  const [, setError] = useState()
  const [, setMap] = useState<mapboxgl.Map>()
  const [data, setData] = useState<FeatureCollection | undefined>(undefined)

  const containerRef = useRef<HTMLDivElement>() as React.MutableRefObject<
    HTMLDivElement
  >
  const mapRef = useRef<mapboxgl.Map>()

  const onSubmit = async (vals: FormValues) => {
    console.log('submit', vals)

    try {
      // const result = await getAverageBill(vals.category.id!, vals.tags[0])
      const result = await getJSON()
      console.log('result', result)
    } catch (e) {
      setError(e)
    }
  }

  const handleAverageCWClick = async (vals: FormValues) => {
    console.log('submit', vals)

    try {
      // const result = await getAverageBill(vals.category.id!, vals.tags[0])
      const result = await getCreditWorthiness(vals.category.id!, vals.tags[0])
      console.log('result', result)
      console.log('testData', testData)

      result.type = 'FeatureCollection'

      setData(result)
    } catch (e) {
      setError(e)
    }
  }

  const handleAverageAgeClick = async (vals: FormValues) => {
    try {
      const result = await getAverageAge(vals.category.id!, vals.tags[0])
      result.type = 'FeatureCollection'
    } catch (e) {
      setError(e)
    }
  }
  const handleAverageBillClick = async (vals: FormValues) => {
    console.log('submit', vals)

    try {
      const result = await getAverageBill(vals.category.id!, vals.tags[0])

      result.type = 'FeatureCollection'

      setData(result)
    } catch (e) {
      setError(e)
    }
  }

  const addLayer = (id: string) => {
    const l = mapRef.current!.addLayer({
      id: id,
      type: 'fill',
      source: { type: 'geojson', data: data },
      layout: {},
      // property: 'OBJECTID',
      paint: {
        // 'fill-color': getRandomColor(),
        // 'fill-opacity': 0.8,
        'fill-color': [
          'interpolate',
          ['linear'],
          ['get', 'decimalValue'],
          0,
          '#cdecff',
          0.2,
          '#9bd9ff',
          0.3,
          '#68c6ff',
          0.4,
          '#36b3ff',
          0.5,
          '#04a0ff',
          0.6,
          '#0380cc',
          0.7,
          '#026099',
          0.8,
          '#025080',
          0.9,
          '#024066',
        ],

        'fill-opacity': 0.8,
      },
    })
  }

  useEffect(() => {
    mapRef.current = new mapboxgl.Map({
      container: containerRef.current, // container id
      style: 'mapbox://styles/mapbox/streets-v11', // style URL
      center: [14.43, 50.07], // starting position [lng, lat]
      zoom: 11, // starting zoom
    })

    return () => {
      mapRef.current?.remove()
    }
  }, [])

  useEffect(() => {
    if (data) {
      console.log('new data')
      const id = Date.now().toString()
      console.log('adding layer ', id, mapRef.current?.loaded())
      addLayer(id)

      // if (mapRef.current?.loaded()) {
      //   addLayer(id)
      // } else {
      //   mapRef.current!.on('load', () => {
      //     console.log('am i called?')

      //     addLayer(id)
      //   })
      // }

      return () => {
        mapRef.current?.removeLayer(id)
      }
    }
  }, [data])

  return (
    <Layout>
      <Filter
        onSubmit={onSubmit}
        handleAverageAgeClick={handleAverageAgeClick}
        handleAverageBillClick={handleAverageBillClick}
        handleAverageCWClick={handleAverageCWClick}
      ></Filter>
      <MapContainer ref={containerRef} />
    </Layout>
  )
}

export default Dashboard
