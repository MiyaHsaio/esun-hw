import { request } from "../util/http";

const versionUrl = "/v1";

export const postFavoriteProductFilter = (
  { pageIndex, pageSize, sortByAsc, sortName, filterItems }
) => {
  return request({
    url: `${versionUrl}/favoriteProduct/Filter`,
    method: "POST",
    data: {
      pageIndex,
      pageSize,
      sortByAsc,
      sortName,
      filterItems,
    },
  });
};

export const postFavoriteProduct = (
  { name, price, feeRate, account, quantity }
) => {
  return request({
    url: `${versionUrl}/favoriteProduct`,
    method: "POST",
    data: { name, price, feeRate, account, quantity },
  });
};

export const putFavoriteProduct = (
  id,
  { name, price, feeRate, account, quantity }
) => {
  return request({
    url: `${versionUrl}/favoriteProduct/${id}`,
    method: "PUT",
    data: { name, price, feeRate, account, quantity },
  });
};

export const getFavoriteProduct = ( id) => {
  return request({
    url: `${versionUrl}/favoriteProduct/${id}`,
    method: "GET",
  });
};

export const deleteFavoriteProduct = (id) => {
  return request({
    url: `${versionUrl}/favoriteProduct/${id}`,
    method: "DELETE",
  });
};
