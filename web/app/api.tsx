import { FeatureCollection } from 'geojson'

export type Transaction = {
  id: number
  date: string
  change: number
  currency: string
  geoCoordinate: {
    latitude: number
    longitude: number
  }
  brand: string
  category: string
  categoryId: number
  note: string
}

type Category = {
  name: string
}

export const getTransactionById = async (id: string): Promise<Transaction> => {
  const response = await fetch(`https://localhost:5001/Transactions/${id}`)

  if (!response.ok) {
    console.log('error', response)
    throw new Error('Network response was not ok')
  }

  return await response.json()
}

export const getTransactions = async (): Promise<Transaction[]> => {
  const response = await fetch(`https://localhost:5001/Transactions/`)

  if (!response.ok) {
    console.log('error', response)
    throw new Error('Network response was not ok')
  }

  return await response.json()
}

export const getCategoryById = async (id: string): Promise<Category> => {
  const response = await fetch(`https://localhost:5001/Categories/${id}`)

  if (!response.ok) {
    console.log('error', response)
    throw new Error('Network response was not ok')
  }

  return await response.json()
}

export const getAverageBill = async (
  categoryId: number,
  tagId: number
): Promise<FeatureCollection> => {
  const response = await fetch(
    `https://localhost:5001/Transactions/AverageBill/${categoryId}/${tagId}`
  )

  if (!response.ok) {
    console.log('error', response)
    throw new Error('Network response was not ok')
  }

  return await response.json()
}

export const getJSON = async (): Promise<FeatureCollection> => {
  const response = await fetch(`https://localhost:5001/Transactions/ReturnJSON`)

  if (!response.ok) {
    console.log('error', response)
    throw new Error('Network response was not ok')
  }

  return await response.json()
}

export const getCreditWorthiness = async (
  categoryId: number,
  tagId: number
): Promise<FeatureCollection> => {
  const response = await fetch(
    `https://localhost:5001/Transactions/CreditWorthiness/${categoryId}/`
  )

  if (!response.ok) {
    console.log('error', response)
    throw new Error('Network response was not ok')
  }

  return await response.json()
}

export const getAverageAge = async (
  categoryId: number,
  tagId: number
): Promise<FeatureCollection> => {
  const response = await fetch(
    `https://localhost:5001/Transactions/AverageAge/${categoryId}/`
  )

  if (!response.ok) {
    console.log('error', response)
    throw new Error('Network response was not ok')
  }

  return await response.json()
}
