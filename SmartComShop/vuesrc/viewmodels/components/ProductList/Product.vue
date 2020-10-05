<template>
    <div class="col-mb-4">
      <div v-for="item in product" :key="item.Id" class="card mx-3">
        <div class="card-body">
          <h5 class="card-title">{{product.ProductName}}</h5>
          <h6 class="card-subtitle text-muted">{{product.ProductCategory}}</h6>
          <button class="btn btn-success mt-2">${{product.ProductPrice}}</button>
        </div>
        <button
          type="button"
          class="btn btn-sm btn-outline-info dropdown-toggle dropdown-toggle-split DP"
          data-toggle="dropdown"
          aria-haspopup="true"
          aria-expanded="false"
          id="navbarDropdown"
        >
          <span class="sr-only">Toggle Dropdown</span>
        </button>
        <div class="dropdown-menu dropdown-menu-right DP" aria-labelledby="navbarDropdown">
          <a class="dropdown-item btnCli DP rounded-bottom">Details</a>
          <a class="dropdown-item btnCli DP rounded-top">Delete</a>
        </div>
      </div>
    </div>
</template>

<script>
export default {
    props: ['product']
}
</script>