const descendingComparator = (a: any, b: any, orderBy: any): -1 | 1 | 0 => {
  if (b[orderBy] < a[orderBy]) {
    return -1;
  }
  if (b[orderBy] > a[orderBy]) {
    return 1;
  }
  return 0;
};

const getComparator = (order: any, orderBy: any) => {
  return order === "desc"
    ? (a: any, b: any) => descendingComparator(a, b, orderBy)
    : (a: any, b: any) => -descendingComparator(a, b, orderBy);
};

function stableSort(array: any, order: any, orderBy: any) {
  const comparator = getComparator(order, orderBy);
  const stabilizedThis = array?.map((el: any, index: any) => [el, index]);
  stabilizedThis?.sort((a: any, b: any) => {
    const comparatorResult = comparator(a[0], b[0]) as any;
    if (comparatorResult !== 0) {
      return comparatorResult;
    }
    return a[1] - b[1];
  });
  return stabilizedThis?.map((el: any) => el[0]);
}

export default {
  sortRecords: stableSort,
};
