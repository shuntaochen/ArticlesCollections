What is OLAP, it is a data analysis platform and theory. OLAP provides calculation and statistics of data across dimensions.

In OLAP, data is spliced into cubes, dimensions in each cube stand for different statistic aspect.
OLAP analysis usually involves multi datasources. A cube can also be cross datasources.
Since datasource can contain countable talbes and views or using a sql to present data, a cube can also include such.

To support customise reports in cubes, it should support customised parameters which is usually a dictionary that includes the usual query parameter names.

Present form and layout of report usually have nothing to do with the data itself.

Dimensions are always business aspects that requires confirmation. And dimensions are measured by measures, each measure measures some dimension(s).

There is one open-source OLAP library in java, **Mondrian**, this can be used to analyze the data.
