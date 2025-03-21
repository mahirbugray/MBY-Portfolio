module.exports = {
    chainWebpack: (config) => {
      config.plugin("define").tap((args) => {
        args[0]["__VUE_OPTIONS_API__"] = true;
        args[0]["__VUE_PROD_HYDRATION_MISMATCH_DETAILS__"] = false;
        return args;
      });
    },
  };