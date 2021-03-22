import React from 'react'
import { Form, Formik } from 'formik'
import Button from '@material-ui/core/Button'
import Autocomplete, {
  AutocompleteChangeReason,
} from '@material-ui/lab/Autocomplete'
import { Chip, makeStyles, TextField } from '@material-ui/core'
import { categories, Category, tags } from './data'

const initialValues: FormValues = {
  category: { name: '', tags: [] },
  tags: [],
}

type Props = {
  onSubmit: (vals: FormValues) => void
  handleAverageAgeClick: (vals: FormValues) => void
  handleAverageBillClick: (vals: FormValues) => void
  handleAverageCWClick: (vals: FormValues) => void
}

export type FormValues = {
  category: { name: string; id?: number; tags: number[] }
  tags: number[]
}

const useStyles = makeStyles({
  wrapper: {
    padding: '25px',
    width: 'min-content',
    margin: 0,
    background: 'white',
    zIndex: 999,
    position: 'fixed',
    top: 0,
    left: 0,
  },
  chip: {
    margin: 6,
    fontSize: '12px',
  },
  tagsWrapper: {
    display: 'flex',
    flexWrap: 'wrap',
    margin: '6px -6px -6px',
  },
  textField: {
    '& label': {
      fontSize: '14px',
      background: 'white',
      padding: '0 5px 0 0',
    },
  },
  autocomplete: {
    '& input': { fontSize: '14px' },
    marginBottom: 10,
    '& span': {
      fontSize: '10px',
    },
  },
  buttonWrapper: {
    display: 'grid',
    gridAutoFlow: 'row',
    gridGap: 10,
  },
  button: {
    fontSize: '12px',
  },
})

const Filter = ({
  onSubmit,
  handleAverageAgeClick,
  handleAverageBillClick,
  handleAverageCWClick,
}: Props) => {
  const classes = useStyles()

  return (
    <div className={classes.wrapper}>
      <Formik initialValues={initialValues} onSubmit={onSubmit}>
        {({ values, setFieldValue }) => (
          <Form noValidate>
            <>
              <Autocomplete
                className={classes.autocomplete}
                id="combo-box-demo"
                options={categories}
                getOptionLabel={(option: Category) => option.name}
                style={{ width: 300 }}
                onChange={(
                  _: React.ChangeEvent<{}>,
                  value: Category | null,
                  reason: AutocompleteChangeReason
                ) => {
                  setFieldValue('category', value)
                  if (reason === 'clear') {
                    setFieldValue('tags', [])
                  }
                }}
                renderInput={(params) => (
                  <TextField
                    {...params}
                    className={classes.textField}
                    label="Category"
                    variant="outlined"
                  />
                )}
              />
              {values.category?.id && (
                <Autocomplete
                  multiple
                  className={classes.autocomplete}
                  id="combo-box-tags"
                  options={values.category.tags}
                  getOptionLabel={(option: Category) =>
                    tags.find((item) => item.id === option)!.name
                  }
                  style={{ width: 300 }}
                  onChange={(
                    _: React.ChangeEvent<{}>,
                    value: Category | null
                  ) => {
                    setFieldValue('tags', value)
                  }}
                  renderInput={(params) => (
                    <TextField
                      {...params}
                      className={classes.textField}
                      label="Tag"
                      variant="outlined"
                    />
                  )}
                />
              )}
            </>
            <div className={classes.buttonWrapper}>
              <Button
                className={classes.button}
                type="button"
                color="primary"
                variant="contained"
                disabled={!values.category?.id}
                onClick={() => handleAverageBillClick(values)}
              >
                Average Bill
              </Button>
              <Button
                className={classes.button}
                type="button"
                color="primary"
                variant="contained"
                disabled={!values.category?.id}
                onClick={() => handleAverageAgeClick(values)}
              >
                Average Age
              </Button>
              <Button
                className={classes.button}
                type="button"
                color="primary"
                variant="contained"
                disabled={!values.category?.id}
                onClick={() => handleAverageCWClick(values)}
              >
                Average Creditworthiness
              </Button>
            </div>
          </Form>
        )}
      </Formik>
    </div>
  )
}

export default Filter
